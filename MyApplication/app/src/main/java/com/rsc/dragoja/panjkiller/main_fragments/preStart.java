package com.rsc.dragoja.panjkiller.main_fragments;

import android.os.Bundle;
import android.support.annotation.Nullable;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ExpandableListView;
import android.widget.LinearLayout;
import android.widget.ScrollView;

import com.rsc.dragoja.panjkiller.R;
import com.rsc.dragoja.panjkiller.classes.ExpandableListAdapter;
import com.rsc.dragoja.userinterface.BaseFragment;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

/**
 * Created by davor on 21.11.2015..
 */
public class preStart extends BaseFragment {

    ExpandableListAdapter listAdapter;
    ExpandableListView expListView;
    List<String> listDataHeader;
    HashMap<String, List<String>> listDataChild;

    public preStart() {
        this.setName("Tim i pravila");
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState){
        View view = inflater.inflate(R.layout.prestart_layout, container, false);

        return view;
    }

    @Override
    public void onViewCreated(View view, @Nullable Bundle savedInstanceState){
        expListView = (ExpandableListView) getActivity().findViewById(R.id.eList);
        /*scrollView = (ScrollView) getActivity().findViewById(R.id.scrollViewDrawer);*/
        prepareListData();
        listAdapter = new ExpandableListAdapter(getActivity(), listDataHeader, listDataChild, expListView);
        expListView.setAdapter(listAdapter);

    }

    private void prepareListData(){
        listDataHeader = new ArrayList<String>();
        listDataChild = new HashMap<String, List<String>>();

        //Header
        listDataHeader.add("Mečovi");

        //Data
        List<String> mechovi = new ArrayList<String>();
        mechovi.add("Meč 1");
        mechovi.add("Meč 2");

        listDataChild.put(listDataHeader.get(0), mechovi);
    }

/*    @Override
    public void onGroupExpand(int groupPosition){
        LinearLayout.LayoutParams param = (LinearLayout.LayoutParams) expListView.getLayoutParams();
        param.height = (expListView.getChildCount() * expListView.getHeight());
        expListView.setLayoutParams(param);
        expListView.refreshDrawableState();
        scrollView.refreshDrawableState();
    }

    @Override
    public void onGroupCollapse(int groupPosition){
        LinearLayout.LayoutParams param = (LinearLayout.LayoutParams) expListView.getLayoutParams();
        param.height = LinearLayout.LayoutParams.WRAP_CONTENT;
        expListView.setLayoutParams(param);
        expListView.refreshDrawableState();
        scrollView.refreshDrawableState();
    }*/

}
