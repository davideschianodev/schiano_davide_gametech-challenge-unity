package com.unity3d.player;

import android.content.Intent;
import android.os.Bundle;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.FrameLayout;

public class CustomPlayerActivity extends UnityPlayerActivity {

    private ImageView currentImageView;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        handleIntent(getIntent());
    }

    @Override
    protected void onNewIntent(Intent intent) {
        super.onNewIntent(intent);
        handleIntent(intent);

        if ((intent.getFlags() & Intent.FLAG_ACTIVITY_NEW_TASK) != 0) {
            Intent launchIntent = new Intent(this, CustomPlayerActivity.class);
            launchIntent.addFlags(Intent.FLAG_ACTIVITY_REORDER_TO_FRONT);
            startActivity(launchIntent);
        }
    }

    private void handleIntent(Intent intent) {
        if (intent != null && "OPEN_APP_FROM_NOTIFICATION".equals(intent.getAction())) {
			String title = intent.getStringExtra("notificationTitle");
			String message = intent.getStringExtra("notificationMessage");

			if (title != null && message != null) {
				UnityPlayer.UnitySendMessage("UIManagerObject", "HandleNotification", title + "|" + message);
			}

            if (intent.hasExtra("notificationIcon")) {
                int notificationIconId = intent.getIntExtra("notificationIcon", 1);
                showImageOnUI(notificationIconId, 142, 990, 200, 200);
            }
        }
    }

    private void showImageOnUI(int drawableId, int x, int y, int width, int height) {
        if (currentImageView != null) {
            ViewGroup parent = (ViewGroup) currentImageView.getParent();
            if (parent != null) {
                parent.removeView(currentImageView);
            }
        }

        currentImageView = new ImageView(this);

        currentImageView.setImageResource(drawableId);

        FrameLayout.LayoutParams params = new FrameLayout.LayoutParams(width, height);
        params.leftMargin = x;
        params.topMargin = y;

        currentImageView.setTranslationZ(10);
		
        addContentView(currentImageView, params);
    }
}