import 'package:flutter/material.dart';
import 'package:testapp/core/MasterTemplate.dart';

import 'AccountRegisterEdit.dart';
import 'AccountRegisterFinish.dart';

enum AccountRegisterScreenStates {
  initial,
  add,
  finished,
}

class AccountRegisterScreen extends StatefulWidget {
  AccountRegisterScreen();
  @override
  _AccountRegisterScreenState createState() => _AccountRegisterScreenState();
}

class _AccountRegisterScreenState extends State<AccountRegisterScreen> {
//
  AccountRegisterScreenStates state = AccountRegisterScreenStates.add;

  String? selectedAccountRegisterID;

//component variables
  TextEditingController tcSearch = TextEditingController();

  //_AccountRegisterScreenState();

  @override
  void initState() {
    debugPrint("InitState");
    super.initState();
  }

  Widget _buildContent() {
    Widget ret = Container();
    switch (state) {
      case AccountRegisterScreenStates.add:
        ret = AccountRegisterEdit(
          key: ValueKey("staticKey"),
          accountRegisterID: selectedAccountRegisterID,
          onFinish: onFinishAdd,
        );
        break;
      case AccountRegisterScreenStates.addfinished:
        ret = AccountRegisterFinish(
          accountRegisterID: selectedAccountRegisterID,
          onFinish: onFinishFinished,
        );
        break;
      default:
    }

    return ret;
  }

  onFinishAdd() {
    setState(() {
      state = AccountRegisterScreenStates.finished;
    });
  }

  onFinishFinished() {
    setState(() {
      state = AccountRegisterScreenStates.add;
    });
  }

  goHome() {
    selectedAccountRegisterID = null;
    setState(() {
      state = AccountRegisterScreenStates.initial;
    });
  }

  List<String> getSubTitles() {
    List<String> ret = ["Account Register", "List"];

    switch (state) {
      case AccountRegisterScreenStates.add:
        ret.add("Add New");
        break;
      case AccountRegisterScreenStates.finished:
        ret.add("Details");
        break;
      default:
    }
    return ret;
  }

  @override
  Widget build(BuildContext context) {
    return MasterTemplate(
      //showBackButton: true,
      subTitles: getSubTitles(),
      onNavBack: goHome,
      child: _buildContent(),
    );
  }

// end class _AccountRegisterScreenState
}
