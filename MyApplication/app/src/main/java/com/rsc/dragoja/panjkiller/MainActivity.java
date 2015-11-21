package com.rsc.dragoja.panjkiller;

import android.app.ActionBar;
import android.app.Activity;
import android.app.FragmentTransaction;
import android.graphics.Color;
import android.graphics.drawable.ColorDrawable;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;

import com.rsc.dragoja.panjkiller.main_fragments.Game;
import com.rsc.dragoja.panjkiller.main_fragments.afterMatch;
import com.rsc.dragoja.panjkiller.main_fragments.preStart;
import com.rsc.dragoja.panjkiller.main_fragments.profile;
import com.rsc.dragoja.userinterface.MainMenu;

public class MainActivity extends Activity {

    private MainMenu menu = new MainMenu();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        ActionBar bar = getActionBar();
        bar.setBackgroundDrawable(new ColorDrawable(Color.parseColor("#0665D6")));

        menu.initFrag(new preStart(),
            new Game(),
                new afterMatch(),
                new profile());

        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        FragmentTransaction ft = getFragmentManager().beginTransaction();
        ft.replace(R.id.navdrawer, menu);
        ft.commit();
    }

    @Override
    public void onBackPressed(){
        menu.homeFragment();
    }
}
