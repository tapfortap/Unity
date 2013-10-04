/*
 * Licensed under the MIT license
 * http://htmlpreview.github.com/?https://github.com/tapfortap/Documentation/blob/master/License.html
 * Copyright (c) 2013 Tap for Tap
 */

public interface ITapForTapAppWall
{
	void OnReceive();
	void OnShow();
	void OnTap();
    void OnDismiss ();
	void OnFail (string reason);
}
