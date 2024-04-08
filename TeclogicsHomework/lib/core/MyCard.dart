import 'package:flutter/material.dart';

class MyCard extends StatelessWidget {
  final String? title;
  final String? titleDynamic; // avoids translation
  final Widget? header;
  final Widget? footer;
  final Widget body;
  final double paddingBody;
  final double paddingFooter;
  final double elevation;
  final bool showNoHeader;
  final Function? onAction;
  final IconData? iconAction;
  final Color? titleColor;
  final Color? titleTextColor;

  MyCard({
    this.header,
    required this.body,
    this.title,
    this.titleDynamic = "",
    this.footer,
    this.paddingBody = 16,
    this.paddingFooter = 10,
    this.elevation = 1,
    this.showNoHeader = false,
    this.onAction,
    this.iconAction = Icons.close,
    this.titleColor,
    this.titleTextColor,
  });

  Widget makeHeader() {
    return Container(
      color: titleColor, //(titleColor == null) ? Theme.of(myApp.context).secondaryHeaderColor :
      height: 55,
      child: Row(
        children: [
          Expanded(
            child: Padding(
              padding: const EdgeInsets.fromLTRB(20, 8, 8, 0),
              child: Text(title!),
            ),
          ),
          (onAction != null)
              ? Padding(
                  padding: const EdgeInsets.only(right: 20),
                  child: IconButton(
                    icon: Icon(iconAction),
                    onPressed: () {
                      onAction!();
                    },
                  ))
              : Container()
        ],
      ),
    );
  }

  Color? getTitleTextColor() {
    Color? ret = titleTextColor;

    if (titleColor != null && titleTextColor == null) {
      ret = titleColor!;
    }

    return ret;
  }

  @override
  Widget build(BuildContext context) {
    List<Widget> arr = [];

    if ((title != null) && (showNoHeader == false)) {
      arr.add(makeHeader());
      arr.add(Divider(height: 1));
    }

    if (header != null) {
      arr.add(header!);
      arr.add(Divider(height: 1));
    }
    Widget wBody = Container(padding: EdgeInsets.all(paddingBody), child: body);
    arr.add(wBody);

    if (footer != null) {
      arr.add(Divider(height: 1));
      arr.add(
        Container(padding: EdgeInsets.all(paddingFooter), child: footer),
      );
    }

    Widget w = Column(
      crossAxisAlignment: CrossAxisAlignment.start,
      children: arr,
    );

    if (arr.length == 1) {
      w = body;
    }

    w = Card(
        elevation: elevation,
        clipBehavior: (title == null) ? Clip.antiAlias : Clip.none,
        //shape: RoundedRectangleBorder(borderRadius: BorderRadius.all(Radius.circular(9))),
        child: w);

    if (showNoHeader) {
      w = Column(crossAxisAlignment: CrossAxisAlignment.start, children: [
        Container(
          padding: EdgeInsets.all(8),
          child: Text(title! + titleDynamic!, textScaler: TextScaler.linear(1.2)),
        ),
        w,
      ]);
    }
    return w;
  }

// MyCard
}
