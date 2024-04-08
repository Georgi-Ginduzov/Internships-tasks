import 'package:flutter/material.dart';
import 'package:testapp/core/MyCard.dart';

import 'mSubscriptions.dart';

class FrmSummary extends StatefulWidget {
  final List<MSubscription> subscriptions;

  FrmSummary({required this.subscriptions});

  @override
  State<FrmSummary> createState() => _FrmSummaryState();
}

class _FrmSummaryState extends State<FrmSummary> {
  _FrmSummaryState() {}
  @override
  Widget build(BuildContext context) {
    double totalPrice = 0;
    for (var subscription in widget.subscriptions) {
      if (subscription.amount > 0) {
        totalPrice += subscription.price * subscription.amount;
      }
    }
    List<Widget> items = [];
    for (var subscription in widget.subscriptions) {
      if (subscription.amount > 0) {
        items.addAll(
          [
            ListTile(
              title: Text(subscription.name),
              subtitle: Text("${subscription.amount} x ${subscription.price}\$"),
              trailing: Text(
                (subscription.price * subscription.amount).toString(),
                textScaler: TextScaler.linear(1.5),
              ),
            ),
            Divider(),
          ],
        );
      }
    }
    items.add(
      ListTile(
        title: Text(
          "Total",
          textScaler: TextScaler.linear(2),
          style: TextStyle(color: Colors.green),
        ),
        trailing: Text(
          totalPrice.toString(),
          textScaler: TextScaler.linear(2),
          style: TextStyle(color: Colors.green),
        ),
      ),
    );
    return MyCard(
      title: "Summary",
      body: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: items,
      ),
    );
  }
}
