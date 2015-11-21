package com.rsc.dragoja.userinterface;

import android.app.Fragment;

/**
 * Created by davor on 21.11.2015..
 */
public class BaseFragment extends Fragment {

    public String _name;

    public void setName(String name){
        this._name = name;
    }

    public String getName(){
        return this._name;
    }

    public void switchFragment(Fragment fragment, boolean backStack, String tag){
        if(backStack){
            getFragmentManager().beginTransaction().addToBackStack(null)
                    .replace(R.id.container, fragment, tag)
                    .commit();
        } else {
            getFragmentManager().beginTransaction()
                    .replace(R.id.container, fragment, tag)
                    .commit();
        }
    }

}
