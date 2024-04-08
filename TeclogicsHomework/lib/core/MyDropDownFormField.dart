import 'package:flutter/material.dart';
import 'package:testapp/core/MyControls.dart';
import 'package:testapp/core/mList.dart';

class MyDropDownFormField extends StatefulWidget {
  final String label;
  final String? value;
  final List<MList>? items;
  final Future<List<MList>>? fitems;
  final Function(MList?) onChanged;
  final bool isMandatory;
  final bool isReadOnly;
  final double? width;

  MyDropDownFormField({
    super.key,
    required this.label,
    this.value,
    this.items,
    this.fitems,
    required this.onChanged,
    this.isMandatory = true,
    this.isReadOnly = false,
    this.width,
  });

  @override
  _MyDropDownFormFieldState createState() => _MyDropDownFormFieldState(this.label, this.value, this.items, this.fitems, this.onChanged, this.isMandatory);
}

class _MyDropDownFormFieldState extends State<MyDropDownFormField> {
  String label;
  String? value;
  List<MList> data = [];
  Function(MList?) onChanged;
  bool isMandatory;
  List<DropdownMenuItem<String>> items = [];
  TextEditingController tcText = TextEditingController();

  _MyDropDownFormFieldState(
    this.label,
    this.value,
    List<MList>? items,
    Future<List<MList>>? fitems,
    this.onChanged,
    this.isMandatory,
  ) {
    //
    if (value == "") {
      debugPrint("ERROR Value can't be ''");
    }

    this.label = (label) + ((isMandatory) ? "*" : "");

    //tcText.text = (value == null) ? "" : value!;

    if (items != null) {
      data = items;

      _buildItems();
    }
    if (fitems != null) {
      fitems.then((val) {
        setState(() {
          data = val;

          _buildItems();
        });
      });
    }
  }

  _buildItems() {
    bool hasValueMatch = false;
    if (isMandatory == false && data[0].name != "None" && data[0].id != "NULL") {
      items.add(DropdownMenuItem<String>(
        child: Text("None"),
        value: "NULL",
      ));

      // data.insert(0, MList(name: "None", id: "NULL"));
      // if (value == null) {
      //   value = data[0].id;
      // }
    }
    data.forEach((el) {
      items.add(DropdownMenuItem<String>(
        child: Text(el.name),
        value: el.id,
      ));

      //confrim value match with item array, dropbox crashes if value = item from array
      if (value.toString().toLowerCase() == el.id.toString().toLowerCase()) {
        tcText.text = el.name;
        hasValueMatch = true;
      }
    });

    if ((hasValueMatch == false) && (value != null)) {
      //add missing value
      items.add(DropdownMenuItem<String>(
        child: Text("Missing value"),
        value: value,
      ));
    }

//the logic crashes the onchage event - calling it to early trigers setstate that errors
    if ((value == null) && (items.length == 1)) {
      String? v = items[0].value;
      if (v != null) _onChanged(v);
    }
  }

  MList? _findInItems(String? id) {
    MList? ret;
    data.forEach((el) {
      if (el.id == id) {
        ret = el;
      }
    });

    return ret;
  }

  _onChanged(String? val) {
    //called if only one item - can't have set state

    if (val != value) {
      value = val;
      MList? itm;
      // will return null when the "NONE" item is selected
      if (val != null) {
        itm = _findInItems(val);
      }

      if (itm != null && itm.id == "NULL") itm = null;

      onChanged(itm);
    }
  }

  String? _validate(String? value) {
    if (isMandatory) {
      if ((value == null) || (value.isEmpty)) {
        return 'Field is mandatory!';
      }
    }
    return null;
  }

  Widget makeContent() {
    Widget ret;

    if (widget.isReadOnly) {
      return TextFormField(
        readOnly: true,
        maxLength: null,
        decoration: InputDecoration(
          labelText: label,
          border: InputBorder.none,
        ),
        //onTap: showPopup,
        //decoration: MyControls.textInputDecoration(label, suffixIcon: Icon(Icons.arrow_drop_down)),
        controller: tcText,
      );
    }

    if (items.length > 1115) {
      ret = Padding(
          padding: EdgeInsets.only(bottom: 15),
          child: TextFormField(
            readOnly: true,
            validator: _validate,
            decoration: MyControls.textInputDecoration(label, suffixIcon: Icon(Icons.arrow_drop_down)),
            controller: tcText,
          ));
    } else {
      ret = DropdownButtonFormField<String>(
        isExpanded: true, // errors without that on fixed sizes around 260 for some reson
        decoration: MyControls.textInputDecoration(label),
        icon: Icon(Icons.arrow_drop_down),
        value: value,
        validator: _validate,
        //hint: Text("Please Select"),
        items: items,
        onChanged: _onChanged, padding: EdgeInsets.only(bottom: 16),
      );
    }

    return ret;
  }

  @override
  Widget build(BuildContext context) {
    Widget w = makeContent();
    if (widget.width != null) {
      w = SizedBox(width: widget.width, child: w);
    }
    return w;
  }

//
}// END class _MyDropDownFormFieldState
