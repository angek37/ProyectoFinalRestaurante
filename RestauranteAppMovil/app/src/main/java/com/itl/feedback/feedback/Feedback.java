package com.itl.feedback.feedback;

import android.app.Application;

import com.android.volley.RequestQueue;
import com.android.volley.toolbox.Volley;

/**
 * Created by desarrollo3 on 25/04/18.
 */

public class Feedback extends Application {
    private static RequestQueue requestQueue;

    public static RequestQueue getRequestQueue() {
        return requestQueue;
    }

    @Override
    public void onCreate() {
        super.onCreate();
        requestQueue = Volley.newRequestQueue(getApplicationContext());
    }
}
