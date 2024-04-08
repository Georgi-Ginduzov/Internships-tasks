import 'dart:async';

import 'package:testapp/core/Tools.dart';
import 'package:testapp/core/mCountries.dart';
import 'package:testapp/core/mCurrency.dart';
import 'package:testapp/core/mList.dart';

class MyStaticData {
  static List<MCountry> countries = [];
  static List<MCurrency> currencies = [];
  static List<MList> states = [];

  // the static may need to be removed if multiple calls of the function do not create new copeters
  // completer can only once be completed
  static Future<List<MCountry>>? loadCountries() {
    var c = Completer<List<MCountry>>();
    countries = [];
    Tools.loadJsonAsset('data/Countries.json').then((data) {
      data.forEach((el) {
        //debugPrint(el);
        countries.add(MCountry.fromMap(el));
      });
      c.complete(countries);
    });
    return c.future;
  }

  static Future<List<MList>>? loadStatesUS() {
    var c = Completer<List<MList>>();
    states = [];
    Tools.loadJsonAsset('data/StatesUSA.json').then((data) {
      data.forEach((el) {
        //debugPrint(el);
        states.add(MList.fromMap(el));
      });
      c.complete(states);
    });
    return c.future;
  }

  static Future<List<MCurrency>>? loadCurrencies() {
    var c = Completer<List<MCurrency>>();
    currencies = [];
    Tools.loadJsonAsset('data/Currencies.json').then((data) {
      data.forEach((el) {
        //debugPrint(el);
        currencies.add(MCurrency.fromMap(el));
      });
      c.complete(currencies);
    });
    return c.future;
  }

// end class MyStaticData
}
