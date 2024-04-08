import 'package:flutter/material.dart';

class MyButton extends StatelessWidget {
  final String label;
  final Function()? onPressed;
  final IconData? icon;
  final Color? color;
  final Color? colorText;
  final bool isOutlined;
  final EdgeInsetsGeometry padding;
  final bool isDisabled;
  final bool isCompact;
  final double minWidth;
  final MyButtonControler? controler;

  MyButton({
    super.key,
    required this.label,
    this.onPressed,
    this.icon,
    this.color,
    this.colorText,
    this.isOutlined = false,
    this.padding = const EdgeInsets.all(10),
    this.isDisabled = false,
    this.isCompact = false,
    this.minWidth = 100,
    this.controler,
  });

  Widget buttonElevated({
    required String label,
    Function()? onPressed,
    IconData? icon,
    Color? color,
    Color? colorText,
    bool isOutlined = false,
    required EdgeInsetsGeometry padding,
    bool isDisabled = false,
  }) {
    ButtonStyle? style;

    if (colorText == null) {
      colorText = Colors.white;
    }

    // if (color != null) {
    if (isOutlined) {
      style = OutlinedButton.styleFrom(
        padding: EdgeInsets.all(0),
        minimumSize: (isCompact) ? Size(minWidth, 12) : Size(minWidth, 24),
        //visualDensity: (isCompact) ? VisualDensity.compact : null,
        foregroundColor: color, // background
        //onPrimary: colorText, // foreground
      );
    } else {
      style = ElevatedButton.styleFrom(
        padding: EdgeInsets.all(0),
        minimumSize: (isCompact) ? Size(minWidth, 12) : Size(minWidth, 24),
        backgroundColor: color, // background
        foregroundColor: colorText, // foreground
      );
    }
    //}

    _onPressed() {
      // debugPrint("MyButton, isDisabled: $isDisabled");

      if ((isDisabled == false) && (onPressed != null)) {
        if (controler == null) {
          onPressed();
        } else {
          // debugPrint("MyButton, controler!.enabled: ${controler!.enabled}");
          if (controler!.enabled) {
            controler!.enabled = false;
            onPressed();
          }
        }
      }
    }

    Widget child = Container(padding: padding, child: Text(label));

    if (icon == null) {
      if (isOutlined) {
        return OutlinedButton(style: style, onPressed: _onPressed, child: child);
      } else {
        return ElevatedButton(style: style, onPressed: _onPressed, child: child);
      }
    } else {
      child = Container(padding: padding, child: Row(children: [Icon(icon), Text(label)]));
      if (isOutlined) {
        return OutlinedButton.icon(style: style, onPressed: _onPressed, icon: Icon(icon), label: child);
      } else {
        return ElevatedButton(style: style, onPressed: _onPressed, child: child);
      }
    }
  }

  @override
  Widget build(BuildContext context) {
    return buttonElevated(
      label: label,
      onPressed: onPressed,
      icon: icon,
      color: color,
      colorText: colorText,
      isOutlined: isOutlined,
      padding: padding,
      isDisabled: isDisabled,
    );
  }

  factory MyButton.submit({Function()? onPressed, String label = "Submit", MyButtonControler? ctl}) {
    return MyButton(
      label: label,
      onPressed: onPressed,
      color: Colors.blue,
      controler: ctl,
    );
  }

  factory MyButton.future({required Future<dynamic> Function() onPressed, String label = "Submit", bool isDisabled = false}) {
    MyButtonControler ctl = MyButtonControler();

    return MyButton(
      label: label,
      onPressed: () {
        onPressed().then((value) {
          ctl.enabled = true;
        });
      },
      color: Colors.blue,
      controler: ctl,
      isDisabled: isDisabled,
    );
  }
}

class MyButtonControler {
  MyButtonControler({this.enabled = true});
  bool enabled = true;
}
