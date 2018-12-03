package com.itl.feedback.feedback;

import android.app.Activity;
import android.os.AsyncTask;
import android.util.Log;
import android.widget.Toast;

import com.android.volley.RequestQueue;
import com.android.volley.toolbox.RequestFuture;
import com.android.volley.toolbox.StringRequest;

import org.json.JSONArray;
import org.json.JSONObject;

/**
 * Created by desarrollo3 on 23/11/2016.
 */
public class SyncServerTask extends AsyncTask<Void, Void, Boolean> {
    private String preguntasURL = "https://restaurante-apps-moviles.herokuapp.com/api/pregunta";
    private Consumer<Boolean> resultConsumer;
    private Activity activity;
    private boolean result;
    private String mensaje;
    private JSONArray arreglo;

    public SyncServerTask(Activity activity, Consumer<Boolean> resultConsumer) {
        this.activity = activity;
        this.resultConsumer = resultConsumer;
    }

    @Override
    protected Boolean doInBackground(Void... voids) {
        result = true;

        try {
            RequestQueue queue = Feedback.getRequestQueue();
            RequestFuture<String> syncFuture = RequestFuture.newFuture();

            StringRequest request = new Consultar(preguntasURL, syncFuture, syncFuture);
            queue.add(request);

            String syncResponse = syncFuture.get();
            arreglo = new JSONArray(syncResponse);

            mensaje = "Se cargaron las preguntas correctamente";
        } catch (Exception e) {
            e.printStackTrace();
            mensaje = "Ocurrió un error.";
        }

        return result;
    }

    @Override
    protected void onPreExecute() {
        super.onPreExecute();

    }

    @Override
    protected void onPostExecute(Boolean result) {
        try {
            if (resultConsumer != null) {
                resultConsumer.consume(this.result);
                Toast.makeText(activity, mensaje, Toast.LENGTH_LONG).show();
                OrdenarMain3.updatePreguntas(arreglo);
            }
        } catch (Exception ex) {
            ex.printStackTrace();
        }
        resultConsumer = null;
    }
}
