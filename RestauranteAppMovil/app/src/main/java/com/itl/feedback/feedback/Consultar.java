package com.itl.feedback.feedback;

import com.android.volley.Response;
import com.android.volley.toolbox.StringRequest;

/**
 * Created by desarrollo3 on 23/04/18.
 */

public class Consultar extends StringRequest {
    private String json;

    public Consultar(String url, Response.Listener<String> listener, Response.ErrorListener errorListener) {
        super(Method.GET, url, listener, errorListener);
    }

    public Consultar(String json, String url, Response.Listener<String> listener, Response.ErrorListener errorListener) {
        super(Method.POST, url, listener, errorListener);
        this.json = json;
    }
}
