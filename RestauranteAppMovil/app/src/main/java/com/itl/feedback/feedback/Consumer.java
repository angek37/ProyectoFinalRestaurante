package com.itl.feedback.feedback;

/**
 * Created by desarrollo3 on 26/04/18.
 */

public interface Consumer<T> {
    void consume(T t);
}
