package com.itl.feedback.feedback;

import android.app.Activity;
import android.app.ProgressDialog;
import android.content.Context;

/**
 * Created by Damián on 26/04/18.
 */

public class SincronizarInformacion {

    public static void SincInf (Activity activity, final Context context){
        final ProgressDialog pgDialog = new ProgressDialog(context);
        pgDialog.setProgressStyle(ProgressDialog.STYLE_SPINNER);
        pgDialog.setCancelable(false);
        pgDialog.setMessage("Obteniendo preguntas... \nEspere un momento");
        pgDialog.show();

        new SyncServerTask(activity, new Consumer<Boolean>(){
            @Override
            public void consume(Boolean aBoolean) {
                pgDialog.dismiss();
            }
        }).execute();

    }
}
