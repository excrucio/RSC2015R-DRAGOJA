package com.rsc.dragoja.panjkiller;

import android.content.Context;
import android.view.GestureDetector;
import android.view.MotionEvent;
import android.view.View;

/**
 * Created by davor on 22.11.2015..
 */
public class OnSwipeTouchListener implements View.OnTouchListener {

    private final GestureDetector gestureDetector;

    public OnSwipeTouchListener (Context ctx){
        gestureDetector = new GestureDetector(ctx, new GestureListener());
    }

    private final class GestureListener extends GestureDetector.SimpleOnGestureListener {
        private static final int SWIPE_TRESHOLD = 100;
        private static final int SWIPE_VELOCITY_TRESHOLD = 100;

        @Override
        public void onLongPress(MotionEvent e){
            onLongClick();
        }

        @Override
        public boolean onDown(MotionEvent e){
            return true;
        }

        @Override
        public boolean onFling(MotionEvent e1, MotionEvent e2, float velocityX, float velocitiyY){
            boolean result = false;

            try {
                float diffY = e2.getY() - e1.getY();
                float diffX = e2.getX() - e1.getX();

                if(Math.abs(diffX) > Math.abs(diffY)){
                    if(Math.abs(diffX) > SWIPE_TRESHOLD && Math.abs(velocityX) > SWIPE_VELOCITY_TRESHOLD){
                        if(diffX > 0){
                            onSwipeRight();
                        } else {
                            onSwipeLeft();
                        }
                    }
                    result = true;
                }
                else if(Math.abs(diffY) > SWIPE_TRESHOLD && Math.abs(velocitiyY) > SWIPE_VELOCITY_TRESHOLD){
                    if (diffY > 0){
                        onSwipeBottom();
                    } else {
                        onSwipeTop();
                    }
                }
                result = true;
            } catch (Exception e){
                e.printStackTrace();
            }

            return result;
        }
    }

    public void onLongClick(){

    }

    public void onSwipeRight(){

    }

    public void onSwipeLeft(){

    }

    public void onSwipeTop() {

    }

    public void onSwipeBottom() {

    }

    public boolean onTouch(View v, MotionEvent event){
        return gestureDetector.onTouchEvent(event);
    }

}
