import 'package:flutter/material.dart';

IdiomRegisterInit() {}

MyCmSysApp myApp = MyCmSysApp();

class MyCmSysApp {
  MyCmSysApp() {}

  @override
  String get commAddress {
    String ret = "";

    return ret;
  }

  @override
  checkForSavedCredentials() {}

  onInitFinish() {
    debugPrint("onInitFinish");
  }

// end class MyAppManager
}
