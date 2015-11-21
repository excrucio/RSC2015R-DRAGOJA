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
public class profile extends BaseFragment {

    public profile(){
        this.setName("Profil");
    }

    @Override
    public View onCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState){
        View view = inflater.inflate(R.layout.profile_layout, container, false);

        return view;
    }

}
