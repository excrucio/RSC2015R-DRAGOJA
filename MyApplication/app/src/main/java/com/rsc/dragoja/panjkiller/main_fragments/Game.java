package com.rsc.dragoja.panjkiller.main_fragments;

import android.content.Context;
import android.location.Location;
import android.location.LocationManager;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Toast;

import com.google.android.gms.location.LocationListener;
import com.google.android.gms.maps.CameraUpdateFactory;
import com.google.android.gms.maps.GoogleMap;
import com.google.android.gms.maps.MapFragment;
import com.google.android.gms.maps.model.LatLng;
import com.rsc.dragoja.panjkiller.OnSwipeTouchListener;
import com.rsc.dragoja.panjkiller.R;
import com.rsc.dragoja.userinterface.BaseFragment;

/**
 * Created by davor on 21.11.2015..
 */
public class Game extends BaseFragment implements LocationListener{

    private View view;
    private boolean exists = false;
    private GoogleMap map;
    private View clicker;

    public Game(){
        this.setName("Igra");
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState){
        if(!exists) {

            view = inflater.inflate(R.layout.game_layout, container, false);
            exists = true;
        }

        MapFragment mf = (MapFragment) getFragmentManager().findFragmentById(R.id.maps);
        map = mf.getMap();
        map.setMyLocationEnabled(true);
        LocationManager locationManager = (LocationManager) getActivity().getSystemService(Context.LOCATION_SERVICE);
        map.getUiSettings().setAllGesturesEnabled(false);
        map.getUiSettings().setCompassEnabled(true);

        Location location = locationManager.getLastKnownLocation(LocationManager.PASSIVE_PROVIDER);
        if(location != null){
            onLocationChanged(location);
        }

        return view;
    }

    @Override
    public void onViewCreated(View view, @Nullable Bundle savedInstanceState){
        super.onViewCreated(view, savedInstanceState);

        clicker = getActivity().findViewById(R.id.empty);

        clicker.setOnTouchListener(new OnSwipeTouchListener(getActivity()){
            public void onSwipeTop(){
                Toast.makeText(getActivity(), "top", Toast.LENGTH_SHORT).show();
            }
            public void onSwipeRight(){
                Toast.makeText(getActivity(), "right", Toast.LENGTH_SHORT).show();
            }
            public void onSwipeLeft(){
                Toast.makeText(getActivity(), "left", Toast.LENGTH_SHORT).show();
            }
            public void onSwipeBottom(){
                Toast.makeText(getActivity(), "bottom", Toast.LENGTH_SHORT).show();
            }
            public void onLongClick(){
                Toast.makeText(getActivity(), "long", Toast.LENGTH_SHORT).show();
            }
        });
    }

    @Override
    public void onLocationChanged(Location location){
        double latitude = location.getLatitude();
        double longitude = location.getLongitude();

        LatLng latLng = new LatLng(latitude, longitude);
        map.moveCamera(CameraUpdateFactory.newLatLng(latLng));
        map.animateCamera(CameraUpdateFactory.zoomTo(15));
    }
}