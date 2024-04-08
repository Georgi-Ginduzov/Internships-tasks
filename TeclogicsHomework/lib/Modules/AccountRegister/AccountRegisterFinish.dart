import 'package:flutter/material.dart';
import 'package:testapp/core/MyCard.dart';

import 'AccountRegisterDB.dart';
import 'mAccountRegister.dart';

class AccountRegisterFinish extends StatefulWidget {
  final String? accountRegisterID;
  final Function onFinish;

  const AccountRegisterFinish({super.key, this.accountRegisterID, required this.onFinish});

  @override
  State<AccountRegisterFinish> createState() => _AccountRegisterFinishState(this.accountRegisterID);
}

class _AccountRegisterFinishState extends State<AccountRegisterFinish> {
  AccountRegisterDB db = AccountRegisterDB();

  MAccountRegister currentAccountRegister = MAccountRegister();
  bool isAccountRegisterReadOnly = true;
  bool isPropertiesReadOnly = true;

  _AccountRegisterFinishState(String? id) {}

  Widget makeAccountRegisterResult() {
    List<Widget> items = [];

    items.addAll([
      Text("Your profile was registered!"),
    ]);

    return Center(
      child: Container(
        width: 400,
        child: MyCard(
          body: Column(children: items),
        ),
      ),
    );
  }

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: EdgeInsets.fromLTRB(8, 16, 8, 16),
      child: Wrap(
        spacing: 20,
        runSpacing: 20,
        children: [
          makeAccountRegisterResult(),
        ],
      ),
    );
  }

  // end class _AccountRegisterFinishState
}
