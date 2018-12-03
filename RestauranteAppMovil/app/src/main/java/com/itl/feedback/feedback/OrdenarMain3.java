// ---------- Menu de ordenar y mandar correo --------------
// --------- cuestionario ----------
package com.itl.feedback.feedback;


import android.content.Context;
import android.os.StrictMode;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.EditText;
import android.widget.RadioGroup;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.JsonObjectRequest;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.FileOutputStream;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;
import java.util.Properties;

import javax.activation.DataHandler;
import javax.activation.DataSource;
import javax.activation.FileDataSource;
import javax.mail.Authenticator;
import javax.mail.Message;
import javax.mail.Multipart;
import javax.mail.PasswordAuthentication;
import javax.mail.Session;
import javax.mail.Transport;
import javax.mail.internet.InternetAddress;
import javax.mail.internet.MimeBodyPart;
import javax.mail.internet.MimeMessage;
import javax.mail.internet.MimeMultipart;

public class OrdenarMain3 extends AppCompatActivity {
    private String respuestasURL = "https://restaurante-apps-moviles.herokuapp.com/api/respuesta";
    private Button enviar;
    private String correo;
    private String pass;
    private Session sesion;
    private EditText nombre, imagen, escuela, encuesta;
    private RadioGroup genero, estudiar;
    private ArrayList<String> dias;
    private static TextView pregunta1, pregunta2, pregunta3,
            pregunta4, pregunta5, pregunta6, pregunta7;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_ordenar_main3);

        correo = "mayrav867@gmail.com";
        pass = "MAYra0926";
        dias = new ArrayList<String>();
        enviar = (Button) findViewById(R.id.enviar);
        nombre = (EditText) findViewById(R.id.nombre);
        genero = (RadioGroup) findViewById(R.id.genero);
        imagen = (EditText) findViewById(R.id.imagen);
        estudiar = (RadioGroup) findViewById(R.id.estudiar);
        escuela = (EditText) findViewById(R.id.escuela);
        encuesta = (EditText) findViewById(R.id.encuesta);
        pregunta1 = (TextView) findViewById(R.id.pregunta1);
        pregunta2 = (TextView) findViewById(R.id.pregunta2);
        pregunta3 = (TextView) findViewById(R.id.pregunta3);
        pregunta4 = (TextView) findViewById(R.id.pregunta4);
        pregunta5 = (TextView) findViewById(R.id.pregunta5);
        pregunta6 = (TextView) findViewById(R.id.pregunta6);
        pregunta7 = (TextView) findViewById(R.id.pregunta7);

        enviar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
//                enviarCorreo();
                enviarRespuestas();
            }
        });

        SincronizarInformacion.SincInf(this, this);
    }

    public static void updatePreguntas(JSONArray preguntas) {
        JSONObject pregunta;
        try {
            pregunta = (JSONObject) preguntas.get(0);
            pregunta1.setText(pregunta.getString("enunciado"));
            pregunta = (JSONObject) preguntas.get(1);
            pregunta2.setText(pregunta.getString("enunciado"));
            pregunta = (JSONObject) preguntas.get(2);
            pregunta3.setText(pregunta.getString("enunciado"));
            pregunta = (JSONObject) preguntas.get(3);
            pregunta4.setText(pregunta.getString("enunciado"));
            pregunta = (JSONObject) preguntas.get(4);
            pregunta5.setText(pregunta.getString("enunciado"));
            pregunta = (JSONObject) preguntas.get(5);
            pregunta6.setText(pregunta.getString("enunciado"));
            pregunta = (JSONObject) preguntas.get(6);
            pregunta7.setText(pregunta.getString("enunciado"));
        } catch (JSONException e) {
            e.printStackTrace();
        }

    }

    public String crearMensaje () {
        String mensaje = "";

        mensaje += "Nombre: " + nombre.getText().toString() + "\n";

        if (genero.getCheckedRadioButtonId() == R.id.hombre) {
            mensaje += "Genero: Masculino" + "\n";
        } else {
            mensaje += "Genero: Femenino" + "\n";
        }

        mensaje += "Comidas Especiales " + imagen.getText().toString() + "\n";

        mensaje += "¿Que desea ordenar? ";
        for (String dia : dias) {
            mensaje += dia + ", ";
        }
        mensaje += "\n";

        if (estudiar.getCheckedRadioButtonId() == R.id.si) {
            mensaje += "Te gusto el servicio?: Si" + "\n";
        } else if (estudiar.getCheckedRadioButtonId() == R.id.no) {
            mensaje += "Te gusto el servicio?: No" + "\n";
        } else {
            mensaje += "Te gusto el servicio?: Más o menos" + "\n";
        }

        mensaje += "¿Te gusto el restaurante?: " + escuela.getText().toString() + "\n";

        mensaje += "Recomendaciones: " + encuesta.getText().toString() + "\n";

        return mensaje;
    }

    public void enviarCorreo() {
        StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder().permitAll().build();
        StrictMode.setThreadPolicy(policy);
        Properties properties = new Properties();
        properties.put("mail.smtp.host", "smtp.gmail.com");
        properties.put("mail.smtp.socketFactory.port", "465");
        properties.put("mail.smtp.socketFactory.class", "javax.net.ssl.SSLSocketFactory");
        properties.put("mail.smtp.auth", "true");
        properties.put("mail.smtp.port", "465");

        try {
            sesion = Session.getDefaultInstance(properties, new Authenticator() {
                @Override
                protected PasswordAuthentication getPasswordAuthentication() {
                    return new PasswordAuthentication(correo, pass);
                }
            });

            if (sesion != null) {
                String filename = "respuestas.txt";
                FileOutputStream fos = openFileOutput(filename, Context.MODE_PRIVATE);
                fos.write(crearMensaje().getBytes());
                fos.close();

                MimeBodyPart archivoAdjunto = new MimeBodyPart();
                DataSource source = new FileDataSource(this.getFilesDir().getPath() + "/" + filename);
                archivoAdjunto.setDataHandler(new DataHandler(source));
                archivoAdjunto.setFileName(filename);

                Multipart multipart = new MimeMultipart();
                multipart.addBodyPart(archivoAdjunto);

                Message message = new MimeMessage(sesion);
                message.setFrom(new InternetAddress(correo));
                message.setSubject("Email de prueba");
                message.setRecipients(Message.RecipientType.TO, InternetAddress.parse(correo));
//                message.setContent(crearMensaje(), "text/html; charset=utf-8");
                message.setContent(multipart);
                Transport.send(message);
            }

            Toast.makeText(this, "Se ha enviado el correo correctamente.", Toast.LENGTH_SHORT).show();
        } catch (Exception e) {
            e.printStackTrace();
            Toast.makeText(this, "Ha ocurrido un error", Toast.LENGTH_SHORT).show();
        }
    }

    public void enviarRespuestas() {
        final Context context = this;

        try {
            RequestQueue queue = Feedback.getRequestQueue();

            JsonObjectRequest guardar = new JsonObjectRequest(Request.Method.POST, respuestasURL, respuesta(),
                    new Response.Listener<JSONObject>() {
                        @Override
                        public void onResponse(JSONObject response) {
                            Toast.makeText(context, "Se ha mandado correctamente", Toast.LENGTH_SHORT).show();
                        }
                    }, new Response.ErrorListener() {
                @Override
                public void onErrorResponse(VolleyError e) {
                    e.printStackTrace();
                    Toast.makeText(context, "Ocurrió un error intentando conectar con el servidor. \nInténtelo de nuevo más tarde.", Toast.LENGTH_SHORT).show();
                }
            });

            queue.add(guardar);

        } catch (Exception e) {
            Toast.makeText(context, "Ocurrió un error intentando conectar con el servidor. \nInténtelo de nuevo más tarde.", Toast.LENGTH_SHORT).show();
        }
    }

    public JSONObject respuesta() {
        JSONObject json = new JSONObject();
        try {
            json.put("nombre", nombre.getText().toString());
            json.put("genero", (genero.getCheckedRadioButtonId() == R.id.hombre ? "Masculino" : "Femenino"));
            json.put("servicio", (estudiar.getCheckedRadioButtonId() == R.id.si));
            json.put("restaurante", true);
            json.put("recomendaciones", encuesta.getText().toString());
            json.put("calificacion", Integer.parseInt(escuela.getText().toString()));
        } catch (JSONException e) {
            e.printStackTrace();
        }

        return json;
    }

    public void listaDias(Boolean checked, String dia) {
        if (checked) {
            dias.add(dia);
        } else {
            dias.remove(dia);
        }
    }

    public void seleccionarCheck(View view) {
        boolean checked = ((CheckBox) view).isChecked();

        switch (view.getId()) {
            case R.id.checkLunes: listaDias(checked, "Enchiladas"); break;
            case R.id.checkMartes: listaDias(checked, "Pozole"); break;
            case R.id.checkMiercoles: listaDias(checked, "Coca-Cola"); break;
            case R.id.checkJueves: listaDias(checked, "Pepsi"); break;
            case R.id.checkViernes: listaDias(checked, "Pastel"); break;
            case R.id.checkSabado: listaDias(checked, "Pay"); break;
            case R.id.checkDomingo: listaDias(checked, "Propina"); break;
        }
    }
}
