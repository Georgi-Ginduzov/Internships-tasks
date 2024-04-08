import 'package:flutter/material.dart';
import 'package:testapp/core/MyCard.dart';
import 'package:testapp/core/MyControls.dart';
import 'package:testapp/core/MyDropDownFormField.dart';
import 'package:testapp/core/mList.dart';
import 'mAccountRegister.dart';

class FrmSchoolInfo extends StatelessWidget {
  final GlobalKey<FormState> formKey;
  final MAccountRegister accountRegister;
  final bool isReadOnly;
  final Future<List<MList>> states;
  final Future<List<MList>> countries;

  FrmSchoolInfo({
    required this.formKey,
    required this.states,
    required this.countries,
    required this.accountRegister,
    this.isReadOnly = false,
  });

  @override
  Widget build(BuildContext context) {
    return Form(
      key: formKey,
      child: MyCard(
        title: "School Information",
        body: Padding(
          padding: const EdgeInsets.only(left: 8.0, right: 8.0),
          child: Column(
            children: [
              const Wrap(
                children: [
                  MyControls.textInput(
                    label: "School Name",
                    isMandatory: true,
                    isReadOnly: isReadOnly,
                    onChanged: (val) {
                      accountRegister.schoolName = val;
                    },
                  ),
                  MyControls.textInput(
                    label: "School Address",
                    isMandatory: true,
                    isReadOnly: isReadOnly,
                    onChanged: (val) {
                      accountRegister.schoolAddress = val;
                    },
                  ),
                ],
              ),
              Wrap(
                children: [
                  MyDropDownFormField(
                    label: "School Country",
                    fitems: countries,
                    isMandatory: true,
                    isReadOnly: isReadOnly,
                    onChanged: (val) {
                      accountRegister.schoolState = val!.id;
                    },
                  ),
                  MyControls.textInput(
                    label: "City",
                    isMandatory: true,
                    isReadOnly: isReadOnly,
                    onChanged: (val) {
                      accountRegister.schoolCity = val;
                    },
                  ),
                  MyDropDownFormField(
                    label: "School State",
                    fitems: states,
                    isMandatory: true,
                    isReadOnly: isReadOnly,
                    onChanged: (val) {
                      accountRegister.schoolState = val!.linkID;
                    },
                  ),
                  MyControls.textInput(
                    label: "School Zip",
                    isMandatory: true,
                    isReadOnly: isReadOnly,
                    onChanged: (val) {
                      accountRegister.schoolZip = val;
                    },
                  ),
                ],
              ),
            ],
          ),
        ),
      ),
    );
  }
}
