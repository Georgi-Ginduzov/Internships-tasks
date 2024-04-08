import 'package:flutter/material.dart';
import 'package:testapp/core/Tools.dart';

class MAccountRegister {
  String? id;
  String? firstName;
  String? lastName;
  String? emailAddress;
  String schoolName;
  String? schoolAddress;
  String? schoolCity;
  String? schoolState;
  String? schoolZip;
  String? password;

  String? createdBy;
  DateTime? createdOn;
  bool isActive = false;
  /* [ID]
      ,[Code]
      ,[Name]
      ,[Address]
      ,[City]
      ,[Zip]
      ,[State]
      ,[CreatedBy]
      ,[CreatedOn]
      ,[isActive]  */
  MAccountRegister();

  Map<String, dynamic> toMap() {
    Map<String, dynamic> ret = {
      'ID': (this.id != '') ? this.id : null, // server side need null for ID not ''
      'FirstName': (this.firstName != '') ? this.firstName : null,
      'LastName': (this.lastName != '') ? this.lastName : null,
      'EmailAddress': (this.emailAddress != '') ? this.emailAddress : null,
      'SchoolName': (this.schoolName != '') ? this.schoolName : null,
      'SchoolAddress': (this.schoolAddress != '') ? this.schoolAddress : null,
      'SchoolCity': (this.schoolCity != '') ? this.schoolCity : null,
      'SchoolState': (this.schoolState != '') ? this.schoolState : null,
      'SchoolZip': (this.schoolZip != '') ? this.schoolZip : null,
      'Password': (this.password != '') ? this.password : null,

      'CreatedOn': this.createdOn.toString(),
      'isActive': this.isActive ? 1 : 0,
    };

    return ret;
  }

  MAccountRegister.fromMap(Map<String, dynamic>? map) {
    if (map == null) {
      debugPrint("MAccountRegisters.fromMap NULL ERROR!");
      return;
    }
    try {
      this.id = map["ID"] ?? null;
      this.firstName = map["FirstName"] ?? null;
      this.lastName = map["LastName"] ?? null;
      this.emailAddress = map["EmailAddress"] ?? null;
      this.schoolName = map["SchoolName"] ?? null;
      this.schoolAddress = map["SchoolAddress"] ?? null;
      this.schoolCity = map["SchoolCity"] ?? null;
      this.schoolState = map["SchoolState"] ?? null;
      this.schoolZip = map["SchoolZip"] ?? null;
      this.password = map["Password"] ?? null;
      this.createdOn = map["CreatedOn"] != null ? DateTime.parse(map["CreatedOn"]) : null;
      this.isActive = Tools.intToBool(map["isActive"], true);
    } catch (e) {
      debugPrint("Error parsing MAccountRegisters.fromMap $e");
    }
  }

  // End Class MAccountRegister
}
