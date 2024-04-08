import 'package:flutter/material.dart';
import 'package:testapp/core/mList.dart';

class MCurrency extends MList {
  String? symbol;
  String? isoCode;
  int sortOrder = 0;
  bool isActive = false;

  MCurrency(
    String id,
    String name,
    this.symbol,
    this.isoCode,
    this.sortOrder,
    this.isActive,
  ) : super(id: id, name: name);

  @override
  Map<String, dynamic> toMap() {
    return {
      'ID': this.id,
      'Name': (this.name != '') ? this.name : null, // server side need null for ID not ''
      'Symbol': (this.symbol != '') ? this.symbol : null, // server side need null for ID not ''
      'ISOCode': (this.isoCode != '') ? this.isoCode : null,
      'SortOrder': this.sortOrder,
      'isActive': this.isActive ? 1 : 0,
    };
  }

  MCurrency.fromMap(Map<String, dynamic>? map) {
    if (map == null) {
      debugPrint("MCurrency.fromMap NULL ERROR!");
      return;
    }
    try {
      this.id = map["ID"] ?? null;
      this.name = map["Name"] ?? null;
      this.symbol = map["Symbol"] ?? null;
      this.isoCode = map["ISOCode"] ?? "0";
      this.sortOrder = map["SortOrder"] ?? 0;
      this.isActive = isActive;
    } catch (e) {
      debugPrint("Error parsing MCurrency.fromMap");
      debugPrint("ERROR!: $e");
    }
  }

// end class MCurrency
}
