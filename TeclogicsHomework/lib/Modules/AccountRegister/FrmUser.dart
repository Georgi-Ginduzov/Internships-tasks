import 'package:flutter/material.dart';
import 'package:testapp/core/MyCard.dart';
import 'package:testapp/core/MyControls.dart';
import 'mAccountRegister.dart';

class FrmUser extends StatelessWidget {
  final GlobalKey<FormState> formKey;
  final MAccountRegister accountRegister;
  final bool isReadOnly;

  FrmUser({
    required this.formKey,
    required this.accountRegister,
    this.isReadOnly = false,
  });

  @override
  Widget build(BuildContext context) {
    return Form(
      key: formKey,
      child: MyCard(
        title: "User Information",
        body: Padding(
          padding: const EdgeInsets.only(left: 8.0, right: 8.0),
          child: Column(
            children: [
              MyControls.textInput(
                label: "Last Name",
                isMandatory: true,
                isReadOnly: isReadOnly,
                onChanged: (val) {
                  accountRegister.lastName = val;
                },
              ),
              MyControls.textInput(
                label: "Email Address",
                isMandatory: true,
                isReadOnly: isReadOnly,
                maxLength: 10,
                validator: (text) {
                  return null;
                },
                onChanged: (val) {
                  accountRegister.emailAddress = val;
                },
              ),
              MyControls.textInput(
                label: "First Name",
                isMandatory: true,
                isReadOnly: true,
                onChanged: (val) {
                  accountRegister.firstName = val;
                },
              ),
              Row(children: [
                Expanded(
                  child: MyControls.textInput(
                    isObscured: true,
                    maxLength: 25,
                    validator: (p0) {
                      if (p0!.length < 8) {
                        return "Min password length 8";
                      }
                    },
                    label: "Password",
                    onChanged: (val) {
                      accountRegister.password = val;
                    },
                  ),
                ),
                Container(width: 10), // spacer
                Expanded(
                  child: MyControls.textInput(
                    isObscured: true,
                    maxLength: 25,
                    validator: (p0) {
                      if (p0 == accountRegister.password) {
                        return "Passwords did not match!";
                      }
                    },
                    label: "Confirm Password",
                  ),
                ),
              ]),
            ],
          ),
        ),
      ),
    );
  }
}
