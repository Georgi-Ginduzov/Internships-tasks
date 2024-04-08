import 'package:testapp/core/MyButton.dart';

import '../../core/MyStaticData.dart';
import '../../core/mList.dart';
import '../Payment/mPaymentInfo.dart';

import 'package:flutter/material.dart';

import 'AccountRegisterDB.dart';
import 'FrmCreditCardInfo.dart';
import 'FrmSchoolInfo.dart';
import 'FrmSubscriptions.dart';
import 'FrmSummary.dart';
import 'FrmUser.dart';
import 'mAccountRegister.dart';
import 'mSubscriptions.dart';

class AccountRegisterEdit extends StatefulWidget {
  final String? accountRegisterID;
  final Function onFinish;

  const AccountRegisterEdit({super.key, this.accountRegisterID, required this.onFinish});

  @override
  State<AccountRegisterEdit> createState() => _AccountRegisterEditState(this.accountRegisterID);
}

class _AccountRegisterEditState extends State<AccountRegisterEdit> {
  AccountRegisterDB db = AccountRegisterDB();
  MAccountRegister currentAccountRegister = MAccountRegister();
  bool isAccountRegisterReadOnly = true;
  bool isPropertiesReadOnly = true;
  MPaymentInfo creditCardInfo = MPaymentInfo();

  final _formUserKey = GlobalKey<FormState>();
  final _formSchoolKey = GlobalKey<FormState>();
  final _formPaymentKey = GlobalKey<FormState>();

  late Future<List<MList>> states;
  late Future<List<MList>> countries;

  _AccountRegisterEditState(String? id) {
    states = MyStaticData.loadStatesUS()!;
    states = MyStaticData.loadCountries()!;
  }

  Widget makeAccountRegisterForm() {
    List<Widget> items = [];

    List<MSubscription> subscriptions = [
      MSubscription.fromMap(
        {"Sort": 0, "ID": "C349606B-6E88-459B-AC44-49BC4360DC95"  "Name": "base package", "Price": 350, "Description": ""},
      ),
      MSubscription.fromMap(
        {"Sort": 1, "ID": "73B8B6A7-B59B-4F52-88BA-6F35C4FADE32", "Name": "Senior Bundle", "Price": 5, "Description": "Prepay for a desired number of Seniors."},
      ),
      MSubscription.fromMap({
        "Sort": 2,
        "ID": "7056260F-9BB9-4F42-830E-955710392E0F",
        "Name": "IdiomCreate™ Faculty Bundle",
        "Price": "99",
        "Description": "Get access to for your entire Faculty & Administration."
      }),
    ];

    items.addAll([
      FrmUser(accountRegister: currentAccountRegister, formKey: _formUserKey),
      SizedBox(height: 20),
      FrmSchoolInfo(accountRegister: currentAccountRegister, states: states, countries: countries, formKey: _formSchoolKey),
      SizedBox(height: 20),
      FrmSubscriptions(subscriptions: subscriptions),
      SizedBox(height: 20),
      FrmSummary(subscriptions: subscriptions),
      SizedBox(
        height: 20,
      ),
      SizedBox(
        height: 20,
      ),
      FrmCreditCardInfo(creditCardInfo: creditCardInfo, formKey: _formPaymentKey, countries: countries, states: states),
      SizedBox(
        height: 20,
      ),
      Row(
        children: [
          Expanded(child: Container()),
          Visibility(
            visible: true,
            child: Container(
              alignment: Alignment.centerRight,
              child: MyButton.submit(onPressed: () {
                if (_validate(context)) {
                  makePayment();
                }
              }),
            ),
          ),
        ],
      ),
    ]);

    return Center(
      child: Container(
        width: 800,
        child: Column(children: items),
      ),
    );
  }

  makePayment() {}

  _validate(BuildContext context) {
    bool isValidUser = false;
    bool isValidSchool = false;
    bool isValidPayment = false;
    FormState? st = _formUserKey.currentState;
    if (st != null) {
      isValidUser = st.validate();
    }

    // school validation
    st = _formSchoolKey.currentState;
    if (st != null) {
      isValidSchool = st.validate();
    }
    // payment validation
    st = _formPaymentKey.currentState;
    if (st != null) {
      isValidPayment = st.validate();
    }
    return isValidUser && isValidSchool && isValidPayment;
  }

  @override
  Widget build(BuildContext context) {
    return Container(
      alignment: Alignment.topCenter,
      padding: EdgeInsets.fromLTRB(8, 16, 8, 16),
      child: makeAccountRegisterForm(),
    );
  }

  // end class _AccountRegisterEditState
}
