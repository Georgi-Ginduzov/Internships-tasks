import 'package:flutter/material.dart';
import 'package:testapp/core/mList.dart';

class MCountry extends MList {
  String currencyID = "";

  MCountry(String id, String name, this.currencyID) : super(id: id, name: name);

  MCountry.fromMap(Map<String, dynamic>? map) {
    if (map == null) {
      debugPrint("MCountry.fromMap NULL ERROR!");
      return;
    }
    try {
      this.id = map["ID"] ?? "";
      this.name = map["Name"] ?? null;
      this.currencyID = map["CurrencyID"] ?? "";
    } catch (e) {
      debugPrint("Error parsing MCountry.fromMap");
      debugPrint("ERROR!: $e");
    }
  }
}
