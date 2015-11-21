package com.rsc.dragoja.panjkiller.main_fragments;

import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.location.Criteria;
import android.location.Location;
import android.location.LocationManager;
import android.os.Bundle;
import android.util.Log;
import android.view.GestureDetector;
import android.view.LayoutInflater;
import android.view.MotionEvent;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Toast;

import com.google.android.gms.location.LocationListener;
import com.google.android.gms.maps.CameraUpdateFactory;
import com.google.android.gms.maps.GoogleMap;
import com.google.android.gms.maps.MapFragment;
import com.google.android.gms.maps.model.LatLng;
import com.rsc.dragoja.panjkiller.R;
import com.rsc.dragoja.userinterface.BaseFragment;

/**
 * Created by davor on 21.11.2015..
 */
public class Game extends BaseFragment implements LocationListener, GoogleMap.OnMapLongClickListener {

    private View view;
    private boolean exists = false;
    private GoogleMap map;

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

        Location location = locationManager.getLastKnownLocation(LocationManager.PASSIVE_PROVIDER);
        if(location != null){
            onLocationChanged(location);
        }

        map.setOnMapLongClickListener(this);

        return view;
    }

    @Override
    public void onLocationChanged(Location location){
        double latitude = location.getLatitude();
        double longitude = location.getLongitude();

        LatLng latLng = new LatLng(latitude, longitude);
        map.moveCamera(CameraUpdateFactory.newLatLng(latLng));
        map.animateCamera(CameraUpdateFactory.zoomTo(15));
    }

    @Override
    public void onMapLongClick(LatLng pint){
        DialogInterface.OnClickListener dialogClickListener = new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                switch(which){
                    case DialogInterface.BUTTON_POSITIVE:
                        Toast.makeText(getActivity(), "Umro!", Toast.LENGTH_SHORT).show();
                        break;
                    case DialogInterface.BUTTON_NEGATIVE:
                        Toast.makeText(getActivity(), "Nije umro!", Toast.LENGTH_SHORT).show();
                        break;
                }
            }
        };

        AlertDialog.Builder builder = new AlertDialog.Builder(getActivity());
        builder.setMessage("Jesi umro?").setPositiveButton("Majkemi", dialogClickListener)
                .setNegativeButton("Ni", dialogClickListener).show();
    }
}
