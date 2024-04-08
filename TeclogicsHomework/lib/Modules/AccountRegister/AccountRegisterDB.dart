import 'dart:async';
import 'dart:core';

import 'package:flutter/material.dart';

enum AccountRegisterSerchTypes { AccountRegisterProperties, PropertyAccountRegister, AccountRegisterUnits, UnitAccountRegister }

class AccountRegisterDB {
  AccountRegisterDB() {}

  Future<Map<String, dynamic>> register(Map<String, dynamic> map) {
    return Future<Map<String, dynamic>>(
      () {
        //send to API here return the result
        return Map<String, dynamic>();
      },
    );
  }

  // end getData

  // end class AccountRegisterDB
}
