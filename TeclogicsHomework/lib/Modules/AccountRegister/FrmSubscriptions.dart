import 'package:flutter/material.dart';
import 'package:testapp/core/MyCard.dart';
import 'package:testapp/core/MyControls.dart';

import 'mSubscriptions.dart';

class FrmSubscriptions extends StatefulWidget {
  List<MSubscription> subscriptions;

  FrmSubscriptions({required this.subscriptions});

  @override
  _FrmSubscriptionsState createState() => _FrmSubscriptionsState();
}

class _FrmSubscriptionsState extends State<FrmSubscriptions> {
  bool isFirstCheckboxSelected = false;
  bool isSecondCheckboxSelected = false;

  double seniorPriceTotal = 0;

  MyCard subscriptions() {
    return MyCard(
      title: "Subscriptions",
      body: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          _seniorsItem(),
          SizedBox(height: 20),
          Text(widget.subscriptions[1].description),
          Divider(height: 40),
          _facultyItem(),
          SizedBox(height: 20),
          Text(widget.subscriptions[2].description),
          // Add additional UI components for the second checkbox here
        ],
      ),
    );
  }

  Widget _facultyItem() {
    return Row(
      children: [
        _checkboxfaculty(),
        Expanded(child: Container()),
        Text((widget.subscriptions[2].price * widget.subscriptions[2].amount).toString(), textScaler: TextScaler.linear(1.5)),
      ],
    );
  }

  Widget _seniorsItem() {
    return Row(
      children: [
        _checkboxSeniors(),
        SizedBox(width: 30),
        _fieldSeniors(),
        Expanded(child: Container()),
        Text((widget.subscriptions[1].price * widget.subscriptions[1].amount).toString(), textScaler: TextScaler.linear(1.5)),
      ],
    );
  }

  Widget _checkboxfaculty() {
    return Container(
      width: 350,
      child: SwitchListTile(
        controlAffinity: ListTileControlAffinity.leading,
        contentPadding: EdgeInsets.all(0),
        title: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Wrap(
              alignment: WrapAlignment.start,
              children: [
                Text(widget.subscriptions[2].name),
                SizedBox(width: 10),
                Text((widget.subscriptions[2].price).toString()),
              ],
            ),
          ],
        ),
        value: isSecondCheckboxSelected,
        onChanged: (newValue) {
          setState(() {
            if (isSecondCheckboxSelected) {
              widget.subscriptions[2].amount = 0;
            } else {
              widget.subscriptions[2].amount = 1;
            }
            isSecondCheckboxSelected = !isSecondCheckboxSelected;
          });
        },
      ),
    );
  }

  Widget _fieldSeniors() {
    return Container(
      width: 200,
      child: MyControls.textInput(
        label: "# of Seniors",
        isMandatory: isFirstCheckboxSelected,
        value: widget.subscriptions[1].amount.toString(),
        isNumeric: true,
        maxLength: 5,
        isReadOnly: !isFirstCheckboxSelected,
        keepTextCarretPositionEnd: true,
        onChanged: (val) {
          // Handle the onChanged event
          if (int.parse(val) > 0) {
            setState(() {
              widget.subscriptions[1].amount = int.parse(val);
              seniorPriceTotal = widget.subscriptions[1].amount * widget.subscriptions[1].price;
            });
          } else {
            setState(() {
              isFirstCheckboxSelected = false;
            });
          }
        },
      ),
    );
  }

  Widget _checkboxSeniors() {
    return Container(
      width: 350,
      child: SwitchListTile(
        controlAffinity: ListTileControlAffinity.leading,
        contentPadding: EdgeInsets.all(0),
        title: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Wrap(
              alignment: WrapAlignment.start,
              children: [
                Text(widget.subscriptions[1].name),
                SizedBox(width: 10),
                Text((widget.subscriptions[1].price).toString()),
              ],
            ),
          ],
        ),
        value: isFirstCheckboxSelected,
        onChanged: (newValue) {
          if (isFirstCheckboxSelected) {
            widget.subscriptions[1].amount = 0;
          } else {
            widget.subscriptions[1].amount = 1;
          }
          setState(() {
            isFirstCheckboxSelected = !isFirstCheckboxSelected;
          });
        },
      ),
    );
  }

  @override
  Widget build(BuildContext context) {
    return subscriptions();
  }
}
