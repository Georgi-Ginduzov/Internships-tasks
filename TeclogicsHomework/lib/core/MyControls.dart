//

import 'package:flutter/material.dart';
import 'package:flutter/services.dart';

// that class is used in statful wigets to expose function for outside calling
class WidgetFunctionExport {
  Function()? execute;
}

class MyControls {
  //

  static Widget textInput({
    required String label,
    TextEditingController? controller,
    bool isMandatory = true,
    int maxLength = 30,
    int? maxLines = 1,
    Function(String val)? onChanged,
    bool isObscured = false,
    bool isCurrency = false,
    Function(String? text)? validator,
    bool isNumeric = false,
    bool isReadOnly = false,
    String? value = "",
    bool keepTextCarretPositionEnd = false, // use this when we call setstate on text change that normaly pushes the carret in front
    bool autofocus = false,
    bool hideCounterText = false,
    TextAlign textAlign = TextAlign.start,
    Function()? onTap,
  }) {
    _onChanged(String val) {
      if (onChanged != null) onChanged(val);
    }

    if (value == null) value = "";
    if (value == 'null') value = "";

    TextEditingController _controller = (controller != null) ? controller : TextEditingController(text: value);
    if (keepTextCarretPositionEnd) {
      _controller.selection = TextSelection.fromPosition(TextPosition(offset: _controller.text.length));
    }

    List<TextInputFormatter>? tf;
    if (isNumeric) {
      tf = [FilteringTextInputFormatter.digitsOnly];
    }

    if (isMandatory) {
      label = "$label *";
    }

    Widget w = TextFormField(
      textAlign: textAlign,
      autofocus: autofocus,
      readOnly: isReadOnly,
      controller: _controller,
      maxLength: (isReadOnly == false) ? maxLength : null,
      maxLines: maxLines,
      inputFormatters: tf,
      maxLengthEnforcement: MaxLengthEnforcement.enforced,
      //decoration: textInputDecoration(I18n.key(label)),
      decoration: (label.length > 0)
          ? textInputDecoration(
              label,
              hideCounterText: hideCounterText,
              isReadOnly: isReadOnly,
            )
          : null,
      validator: (value) {
        if (value == null) {
          return null;
        }

        if (((value.trim().isEmpty)) && (isMandatory)) {
          return 'Field is mandatory!';
        }
        if (validator != null) {
          return validator(value);
        }

        return null;
      },
      onChanged: _onChanged,
      onTap: onTap,
      obscureText: isObscured,
    );

    return w;
  }

  static InputDecoration textInputDecoration(String label, {Widget? suffixIcon, Widget? prefixIcon, bool isReadOnly = false, bool hideCounterText = false, String? prefixText}) {
    return InputDecoration(
      prefixText: prefixText,
      labelText: (label.length > 0) ? (label) : null,
      label: (label.length == 0) ? SizedBox(height: 1, width: 1) : null,
      //helperText: 'pesho',
      contentPadding: EdgeInsets.fromLTRB(0, 8, 0, 1),
      suffixIcon: suffixIcon,
      prefixIcon: prefixIcon,
      border: (isReadOnly) ? InputBorder.none : UnderlineInputBorder(),
      counterText: (hideCounterText) ? " " : null,
    );
  }

  static Widget buttonElevated({
    required String label,
    Function()? onPressed,
    IconData? icon,
    Color? color,
    Color? colorText,
    bool isOutlined = false,
    EdgeInsetsGeometry padding = const EdgeInsets.all(10),
    bool isDisabled = false,
  }) {
    ButtonStyle? style;

    if (colorText == null) {
      colorText = Colors.white;
    }

    if (color != null) {
      if (isOutlined) {
        style = OutlinedButton.styleFrom(
          foregroundColor: color, // background
          //onPrimary: colorText, // foreground
        );
      } else {
        style = ElevatedButton.styleFrom(
          backgroundColor: color, // background
          foregroundColor: colorText, // foreground
        );
      }
    }

    _onPressed() {
      if ((isDisabled == false) && (onPressed != null)) {
        onPressed();
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
      if (isOutlined) {
        return OutlinedButton.icon(style: style, onPressed: _onPressed, icon: Icon(icon), label: child);
      } else {
        return ElevatedButton.icon(style: style, onPressed: _onPressed, icon: Icon(icon), label: child);
      }
    }
  }

  static Widget buttonText({required String label, Function()? onPressed}) {
    return TextButton(onPressed: onPressed, child: Text(label));
  }

  // static Widget speedDial({
  //   Color? foregroundColor = Colors.white,
  //   double? marginEnd = 40,
  //   double? marginBottom = 40,
  //   IconData? icon,
  //   AnimatedIconData? animatedIcon = AnimatedIcons.add_event,
  //   Color? backgroundColor = Colors.green,
  //   String? tooltip,
  //   Function()? onPress,
  // }) {
  //   // need to be unique otherwise trows exeptions
  //   String _uniqueID = DateTime.now().millisecondsSinceEpoch.toString();

  //   return SpeedDial(
  //     foregroundColor: foregroundColor,
  //     // marginEnd: marginEnd!,
  //     // marginBottom: marginBottom!,
  //     animatedIcon: animatedIcon,
  //     // animatedIconTheme: IconThemeData(size: 22.0),
  //     child: (icon != null) ? Icon(icon) : null,
  //     // onPress: addReadingRecord,
  //     backgroundColor: backgroundColor,
  //     activeBackgroundColor: Colors.deepOrange,
  //     curve: Curves.bounceIn,
  //     //overlayColor: Colors.black,
  //     overlayOpacity: 0, // make it transaprent
  //     renderOverlay: false,
  //     closeManually: false,
  //     tooltip: tooltip,
  //     heroTag: _uniqueID, // need to be unique otherwise trows exeptions
  //     elevation: 8.0,
  //     shape: CircleBorder(),
  //     onPress: onPress,
  //   );
  // }

  static Widget twoColumText({required String label, required String label2, bool isLabelBold = false, bool isLabel2Bold = true}) {
    return RichText(
      text: TextSpan(children: [
        TextSpan(text: label, style: (isLabelBold) ? TextStyle(fontWeight: FontWeight.bold) : null),
        TextSpan(text: label2, style: (isLabel2Bold) ? TextStyle(fontWeight: FontWeight.bold) : null),
      ]),
    );
  }

// end class MyControls
}
//
//
//

class MyCheckBox extends StatefulWidget {
  final bool value;
  final Function(bool val)? onChanged;
  final bool isReadOnly;

  MyCheckBox({
    required this.value,
    this.onChanged,
    this.isReadOnly = false,
    super.key,
  });

  @override
  _MyCheckBoxState createState() => _MyCheckBoxState(this.value);
}

class _MyCheckBoxState extends State<MyCheckBox> {
  bool value;
  IconData? ico;

  _MyCheckBoxState(this.value) {
    setIcon();
  }

  // @override
  // void initState() {
  //   debugPrint("init _MyCheckBoxState");
  //   super.initState();
  // }

  setIcon() {
    if (value) {
      ico = Icons.check_box_outlined;
    } else {
      ico = Icons.check_box_outline_blank;
    }
  }

  onPressed() {
    if (widget.onChanged == null) return;

    if (value) {
      value = false;
    } else {
      value = true;
    }
    setIcon();

    widget.onChanged!(value);
    setState(() {});
  }

  @override
  Widget build(BuildContext context) {
    if (widget.isReadOnly) {
      return Icon(ico);
    } else {
      return IconButton(onPressed: onPressed, icon: Icon(ico));
    }
  }
}

//
//
//
//MyCheckBoxFormField

class MyCheckBoxFormField extends StatefulWidget {
  final bool value;
  final Function(bool)? onChanged;
  final String label;
  final bool textBeforeBox;
  final bool isReadOnly;

  MyCheckBoxFormField({
    required this.value,
    this.onChanged,
    required this.label,
    this.textBeforeBox = true,
    this.isReadOnly = false,
  });

  @override
  _MyCheckBoxFormFieldState createState() => _MyCheckBoxFormFieldState(this.value);
}

class _MyCheckBoxFormFieldState extends State<MyCheckBoxFormField> {
  bool _value = false;
  IconData? ico;

  _MyCheckBoxFormFieldState(bool value) {
    _value = value;
  }

  onPressed(bool? val) {
    if (widget.onChanged == null) return;

    if (val != null) {
      setState(() {
        _value = val;
        widget.onChanged!(_value);
      });
    }
  }

  Widget _make() {
    Widget title = Align(alignment: Alignment(-1.1, 0), child: Text(widget.label.trim()));

    return CheckboxListTile(
      contentPadding: EdgeInsets.all(0),
      visualDensity: VisualDensity.compact,
      controlAffinity: ListTileControlAffinity.leading,
      title: title,
      value: _value,
      onChanged: (widget.isReadOnly == false) ? onPressed : null,
    );
  }

  @override
  Widget build(BuildContext context) {
    return _make();
  }
}
// END _MyCheckBoxFormFieldState

//
//
//
// MyIconButton

class MyIconButton extends StatefulWidget {
  final IconData icon;
  final double? size;
  final Function()? onPressed;
  final Color? color;
  final Color? colorText;
  final double padding;
  final bool isCircle;
  final String? tooltip;

  MyIconButton({
    required this.icon,
    required this.onPressed,
    this.size = 24,
    this.color,
    this.colorText,
    this.padding = 10,
    this.isCircle = true,
    this.tooltip,
  });

  @override
  _MyIconButtonState createState() => _MyIconButtonState(this.color, this.isCircle, this.colorText);
}

class _MyIconButtonState extends State<MyIconButton> {
  Color? color;
  Color? colorText;

  //Color? _hoverColor;
  bool isCircle;

  _MyIconButtonState(this.color, this.isCircle, this.colorText);

  @override
  Widget build(BuildContext context) {
    if ((color != null) && (colorText == null)) colorText = Colors.white;

    return ClipOval(
      child: Container(
        //padding: EdgeInsets.all(6),
        color: color,
        child: IconButton(
          padding: EdgeInsets.all(widget.padding),
          tooltip: (widget.tooltip != null) ? (widget.tooltip!) : null,
          iconSize: widget.size,
          icon: Icon(widget.icon),
          color: colorText,
          onPressed: widget.onPressed,
        ),
      ),
    );
  }
}

// ------------------------------------------------
//                  BUTTON

// enum MyButtonShape { rect, circle }

// class MyButton extends StatefulWidget {
//   final IconData? icon;
//   final String? label;
//   final Function()? onPressed;
//   final Color? color;
//   final Color? colorText;
//   final Color? colorHover;
//   final Color? colorBorder;
//   final EdgeInsetsGeometry? padding;
//   final MyButtonShape shape;

//   MyButton({
//     Key? key,
//     this.icon,
//     this.label,
//     this.onPressed,
//     this.color,
//     this.colorText,
//     this.colorHover,
//     this.colorBorder,
//     this.padding = const EdgeInsets.fromLTRB(20, 10, 20, 10),
//     this.shape = MyButtonShape.rect,
//   }) : super(key: key);

//   @override
//   _MyButtonState createState() => _MyButtonState(this.color, this.colorText);

// }

// class _MyButtonState extends State<MyButton> {
//   Color? color;
//   Color? colorText;

//   _MyButtonState(this.color, this.colorText);

//   Widget getContent() {
//     Widget ret = Container();
//     if (widget.icon != null) {
//       ret = Icon(widget.icon);
//     } else {
//       String l = "";
//       if (widget.label != null) l = widget.label!;
//       ret = Text(l, style: TextStyle(color: colorText), textAlign: TextAlign.center, textScaler: TextScaler.linear(1.2));
//     }

//     return Center(child: ret);
//   }

//   @override
//   Widget build(BuildContext context) {
//     if ((color != null) && (colorText == null)) {
//       colorText = Colors.white;
//     }
//     //debugPrint("color" + color.toString());
//     if (widget.shape == MyButtonShape.circle) {
//       return Ink(
//         decoration: ShapeDecoration(
//           color: color,
//           shape: CircleBorder(),
//         ),
//         child: IconButton(
//           icon: getContent(),
//           color: colorText,
//           onPressed: () {
//             if (widget.onPressed != null) {
//               widget.onPressed!();
//             }
//           },
//         ),
//       );
//     } else {
//       return MouseRegion(
//         cursor: SystemMouseCursors.click,
//         child: GestureDetector(
//           onTap: () {
//             if (widget.onPressed != null) {
//               widget.onPressed!();
//             }
//           },
//           child: Card(
//             shape: (widget.colorBorder != null)
//                 ? RoundedRectangleBorder(
//                     borderRadius: BorderRadius.all(Radius.circular(3)),
//                     side: BorderSide(color: widget.colorBorder!),
//                   )
//                 : null,
//             color: color,
//             child: Container(
//               padding: widget.padding,
//               child: getContent(),
//             ),
//           ),
//         ),
//       );
//     }
//   }
// }

// class MyTextField extends StatefulWidget {
//   final String? value;

//   const MyTextField({this.value, super.key});

//   @override
//   _MyTextFieldState createState() => _MyTextFieldState(this.value);
// }

// class _MyTextFieldState extends State<MyTextField> {
//   String? value;
//   TextEditingController ctext = TextEditingController();

//   _MyTextFieldState(this.value) {
//     ctext.text = (value != null) ? value! : "";
//   }

//   @override
//   Widget build(BuildContext context) {
//     return TextField(
//       controller: ctext,
//       decoration: InputDecoration(isDense: true, contentPadding: EdgeInsets.fromLTRB(0, 2, 0, 4)),
//     );
//   }
// }

class MySwitchListTile extends StatefulWidget {
  final Function(bool) onChanged;
  final bool value;
  final String? title;
  final String? subTitle;
  final bool enabled;

  const MySwitchListTile({super.key, required this.onChanged, this.value = false, this.title, this.subTitle, this.enabled = true});

  @override
  State<MySwitchListTile> createState() => _MySwitchListTileState(value);
}

class _MySwitchListTileState extends State<MySwitchListTile> {
  bool value = false;

  _MySwitchListTileState(this.value);

  _onChanged(bool val) {
    setState(() {
      value = val;
      widget.onChanged(val);
    });
  }

  @override
  Widget build(BuildContext context) {
    return ListTile(
      enabled: widget.enabled,
      title: (widget.title != null) ? Text(widget.title!) : null,
      subtitle: (widget.subTitle != null) ? Text(widget.subTitle!) : null,
      onTap: () {
        _onChanged(!value);
      },
      trailing: Switch(
        onChanged: _onChanged,
        value: value,
      ),
    );
  }

  //
}// END class MySwitchListTile
