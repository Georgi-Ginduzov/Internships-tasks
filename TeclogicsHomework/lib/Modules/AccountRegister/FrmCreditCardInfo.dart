import 'package:flutter/material.dart';
import 'package:testapp/core/MyCard.dart';
import 'package:testapp/core/MyControls.dart';
import 'package:testapp/core/MyDropDownFormField.dart';

import 'package:testapp/core/mList.dart';

import '../Payment/mPaymentInfo.dart';

class FrmCreditCardInfo extends StatefulWidget {
  final bool isReadOnly;
  final GlobalKey<FormState> formKey;
  final Future<List<MList>> states;

  final Future<List<MList>> countries;

  final MPaymentInfo creditCardInfo;
  FrmCreditCardInfo({
    required this.states,
    required this.formKey,
    required this.creditCardInfo,
    required this.countries,
    this.isReadOnly = false,
  });

  @override
  _FrmCreditCardInfoState createState() => _FrmCreditCardInfoState();
}

class _FrmCreditCardInfoState extends State<FrmCreditCardInfo> {
  @override
  Widget build(BuildContext context) {
    return Form(
      key: widget.formKey,
      child: MyCard(
        title: "Credit Card Information",
        body: Padding(
          padding: const EdgeInsets.only(left: 8.0, right: 8.0),
          child: Column(
            children: [
              MyControls.textInput(
                keepTextCarretPositionEnd: true,
                label: "Card Number",
                isMandatory: true,
                value: widget.creditCardInfo.number,
                isReadOnly: widget.isReadOnly,
                isNumeric: true,
                maxLength: 19,
                onChanged: (val) {
                  setState(() {
                    widget.creditCardInfo.number = val;
                  });
                },
              ),
              const MyControls.textInput(
                keepTextCarretPositionEnd: true,
                label: "Expiration Year",
                isMandatory: true,
                isNumeric: true,
                maxLength: 4,
                value: widget.creditCardInfo.expYear,
                isReadOnly: widget.isReadOnly,
                onChanged: (val) {
                  setState(() {
                    widget.creditCardInfo.expYear = val;
                  });
                },
              ),
              MyControls.textInput(
                keepTextCarretPositionEnd: true,
                label: "Expiration Month",
                isMandatory: true,
                isNumeric: true,
                maxLength: 2,
                value: widget.creditCardInfo.expMonth,
                isReadOnly: widget.isReadOnly,
                onChanged: (val) {
                  setState(() {
                    widget.creditCardInfo.expMonth = val;
                  });
                },
              ),
              MyControls.textInput(
                keepTextCarretPositionEnd: true,
                label: "CVC",
                isMandatory: true,
                maxLength: 3,
                value: widget.creditCardInfo.cvc,
                isReadOnly: widget.isReadOnly,
                onChanged: (val) {
                  setState(() {
                    widget.creditCardInfo.name = val;
                  });
                },
              ),
              MyControls.textInput(
                keepTextCarretPositionEnd: true,
                label: "Name on Card",
                isMandatory: true,
                value: widget.creditCardInfo.name,
                isReadOnly: widget.isReadOnly,
                onChanged: (val) {
                  setState(() {
                    widget.creditCardInfo.name = val;
                  });
                },
              ),
              MyControls.textInput(
                keepTextCarretPositionEnd: true,
                label: "Billing Address",
                isMandatory: true,
                maxLength: 50,
                value: widget.creditCardInfo.name,
                isReadOnly: widget.isReadOnly,
                onChanged: (val) {
                  setState(() {
                    widget.creditCardInfo.billingAddress = val;
                  });
                },
              ),
              MyControls.textInput(
                keepTextCarretPositionEnd: true,
                label: "Billing City",
                isMandatory: true,
                value: widget.creditCardInfo.name,
                isReadOnly: widget.isReadOnly,
                onChanged: (val) {
                  widget.creditCardInfo.billingCity = val;
                },
              ),
              MyDropDownFormField(
                label: "Billing State",
                isMandatory: true,
                fitems: widget.states,
                isReadOnly: widget.isReadOnly,
                onChanged: (val) {
                  setState(() {
                    widget.creditCardInfo.billingState = val!.id;
                  });
                },
              ),
              MyControls.textInput(
                keepTextCarretPositionEnd: true,
                label: "Billing Zip",
                isMandatory: true,
                maxLength: 10,
                value: widget.creditCardInfo.billingZip,
                isReadOnly: widget.isReadOnly,
                onChanged: (val) {
                  setState(() {
                    widget.creditCardInfo.billingZip = val;
                  });
                },
              ),
              MyDropDownFormField(
                label: "Billing Country",
                isMandatory: true,
                fitems: widget.countries,
                isReadOnly: widget.isReadOnly,
                onChanged: (val) {
                  setState(() {
                    widget.creditCardInfo.billingState = val!.id;
                  });
                },
              ),
            ],
          ),
        ),
      ),
    );
  }
}
