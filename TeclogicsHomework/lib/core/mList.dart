import 'package:flutter/material.dart';

class MList {
  String id = "";
  String name = "";
  String linkID = "";

  MList({this.id = "", this.name = "", this.linkID = ""});

  MList.fromMap(Map<String, dynamic>? map) {
    if (map == null) {
      debugPrint("MList.fromMap NULL ERROR!");
      return;
    }
    try {
      id = map["ID"] ?? null;
      name = map["Name"] ?? '';
      linkID = map["LinkID"] ?? '';
    } catch (e) {
      debugPrint("bat parsing mList: $e");
    }
  }

  Map<String, dynamic> toMap() {
    return {
      'ID': this.id,
      'Name': (this.name != '') ? this.name : null,
      'LinkID': (this.linkID != '') ? this.linkID : null,
    };
  }

//end class MList
}
