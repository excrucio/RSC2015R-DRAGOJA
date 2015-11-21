package com.rsc.dragoja.panjkiller.main_fragments;

import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.rsc.dragoja.panjkiller.R;
import com.rsc.dragoja.userinterface.BaseFragment;

/**
 * Created by davor on 21.11.2015..
 */
public class preStart extends BaseFragment {

    public preStart() {
        this.setName("Tim i pravila");
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState){
        View view = inflater.inflate(R.layout.prestart_layout, container, false);

        return view;
    }

}
