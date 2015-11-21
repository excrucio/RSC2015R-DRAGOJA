package com.rsc.dragoja.userinterface;

import android.app.ActionBar;
import android.content.res.Configuration;
import android.os.Bundle;
import android.support.v4.widget.DrawerLayout;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ListView;

import com.ikimuhendis.ldrawer.ActionBarDrawerToggle;
import com.ikimuhendis.ldrawer.DrawerArrowDrawable;

import java.util.ArrayList;

/**
 * Created by davor on 21.11.2015..
 */
public class MainMenu extends BaseFragment {
    private DrawerLayout mDrawerLayout;
    private ListView mDrawerList;
    private ActionBarDrawerToggle mDrawerToggle;
    private DrawerArrowDrawable drawerArrow;
    private ArrayList<String> values = new ArrayList<String>();
    private ArrayList<BaseFragment> fragments = new ArrayList<BaseFragment>();
    private String currentFrag;

    public void initFrag(BaseFragment... params){
        for (BaseFragment param : params){
            values.add(param.getName());
            this.fragments.add(param);
        }
    }

    @Override
    public void onCreate (Bundle savedInstanceState){
        this.homeFragment();
        super.onCreate(savedInstanceState);

        setHasOptionsMenu(true);

        ActionBar ab = getActivity().getActionBar();
        ab.setDisplayHomeAsUpEnabled(true);
        ab.setHomeButtonEnabled(true);

        mDrawerLayout = (DrawerLayout) getActivity().findViewById(R.id.drawer_layout);
        mDrawerList = (ListView) getActivity().findViewById(R.id.navdrawer);

        drawerArrow = new DrawerArrowDrawable(getActivity()) {
            @Override
            public boolean isLayoutRtl() {
                return false;
            }
        };

        mDrawerToggle = new ActionBarDrawerToggle(getActivity(), mDrawerLayout, drawerArrow, R.string.drawer_open, R.string.drawer_close){
            public void onDrawerClosed(View view){
                getActivity().getActionBar().setTitle(currentFrag);
                getActivity().invalidateOptionsMenu();
            }

            public void onDrawerOpened(View drawerView){
                super.onDrawerOpened(drawerView);

                getActivity().getActionBar().setTitle("PanjKiller");
                getActivity().invalidateOptionsMenu();
            }
        };

        mDrawerLayout.setDrawerListener(mDrawerToggle);
        mDrawerToggle.syncState();

        ArrayAdapter<String> adapter = new ArrayAdapter<String>(getActivity(), android.R.layout.simple_list_item_1, android.R.id.text1, values);
        mDrawerList.setAdapter(adapter);

        mDrawerList.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                currentFrag = fragments.get(position).getName();
                switchFragment(fragments.get(position), false, currentFrag);
                mDrawerLayout.closeDrawer(mDrawerList);
            }
        });
    }

    public void homeFragment(){
        currentFrag = fragments.get(0).getName();
        getActivity().getActionBar().setTitle(currentFrag);
        switchFragment(fragments.get(0), false, currentFrag);
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item){
        if(item.getItemId() == android.R.id.home){
            if(mDrawerLayout.isDrawerOpen(mDrawerList)){
                mDrawerLayout.closeDrawer(mDrawerList);
            } else {
                mDrawerLayout.openDrawer(mDrawerList);
            }
        }
        return super.onOptionsItemSelected(item);
    }

    @Override
    public void onConfigurationChanged(Configuration newConfig){
        super.onConfigurationChanged(newConfig);
        mDrawerToggle.onConfigurationChanged(newConfig);
    }

}
