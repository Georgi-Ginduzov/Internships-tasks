import 'package:flutter/material.dart';

class MasterTemplate extends StatefulWidget {
  final Widget child;
  final String? menuParentID;
  final Color? titleBgrColor;
  final String? titleText;
  final Widget? title;
  final Widget? floatButton;
  //final Widget? childContext;
  //final MasterTemplateFunctions? functions;
  final List<String>? subTitles;
  final List<Widget>? subTitleWidgets;
  final List<Widget>? subTitleActions;
  final bool showBackButton;
  final bool showHomeButton;
  final bool showFeedbackButton;
  final bool showLeftMenu;
  final Widget? sideMenu;
  final double minWidth;
  final double maxWidth;
  final double bottomPadding;
  final Function? onNavBack;
  final Widget? topMenu;
  final bool allowWillPop;
  final Widget? leftBodyContainer;

  MasterTemplate({
    required this.child,
    this.menuParentID,
    this.titleBgrColor,
    this.titleText,
    this.title,
    this.floatButton,
    //this.childContext,
    //this.functions,
    this.subTitles,
    this.subTitleActions,
    this.subTitleWidgets,
    this.showBackButton = true,
    this.showHomeButton = true,
    this.showFeedbackButton = false,
    this.showLeftMenu = false,
    this.sideMenu,
    this.minWidth = 800,
    this.maxWidth = 1200,
    this.bottomPadding = 60,
    this.onNavBack,
    this.topMenu,
    this.allowWillPop = true,
    this.leftBodyContainer,
  });

  @override
  _MasterTemplateState createState() => _MasterTemplateState(this.titleText, this.title, this.titleBgrColor, this.menuParentID
      //this.childContext,
      //this.functions,
      );
}

class _MasterTemplateState extends State<MasterTemplate> {
  Color titleBgrColor = Colors.green;
  GlobalKey<ScaffoldState> currentScaffoldStateKey = GlobalKey<ScaffoldState>();
  List<Widget> lwTitle = [];
  String? menuParentID;
  String? menuParentName;

  bool _isRightContainerVisible = false;
  double _rightContainerFunctionWidht = 0;
  Widget? _rightContainerFunction;

  _MasterTemplateState(String? titleText, Widget? title, Color? titleBgrColor, String? menuParentID) {
    debugPrint("_MasterTemplateState");

    if (title != null) {
      lwTitle.add(title);
    }
    if (titleText != "") {
      lwTitle.add(Text((titleText.toString())));
    }

    if (menuParentID != null) this.menuParentID = menuParentID;
    if (titleBgrColor != null) this.titleBgrColor = titleBgrColor;
  }

  @override
  void dispose() {
    debugPrint('Master Template Dispose used');

    super.dispose();
  }

  @override
  initState() {
    super.initState();
    // myApp.currentScaffoldState = Scaffold.of(context);
  }

  openEndDrawer(dynamic t) {
    debugPrint("openEndDrawer call");
    currentScaffoldStateKey.currentState!.openEndDrawer();
  }

  Color _getTitleItemsColor() {
    Color c = Colors.white;

    if (titleBgrColor == Colors.white) c = Colors.black;
    return c;
  }

  Widget makeleftBodyContainer() {
    debugPrint("makeleftBodyContainer:${widget.leftBodyContainer}");
    if (widget.leftBodyContainer == null) return Container();

    return Card(
      elevation: 6,
      margin: EdgeInsets.all(0),
      shape: RoundedRectangleBorder(),
      child: Container(alignment: Alignment.topCenter, child: widget.leftBodyContainer),
    );
  }

  Widget makeRightContainer() {
    if (_isRightContainerVisible == false) return Container();

    return Container(
      //curve: Curves.fastOutSlowIn,
      //duration: Duration(seconds: 2),

      width: _rightContainerFunctionWidht,
      child: Card(
        elevation: 6,
        margin: EdgeInsets.all(0),
        shape: RoundedRectangleBorder(),
        child: Container(
          alignment: Alignment.topCenter,
          child: _rightContainerFunction,
        ),
      ),
    );
  }

  onSubmenuNavBack() {
    if (widget.onNavBack == null) {
      Navigator.of(context).pop();
    } else {
      widget.onNavBack!();
    }
  }

  Widget makeCore() {
    final _scrollController = ScrollController(initialScrollOffset: 0);
    return Scrollbar(
      controller: _scrollController,
      thumbVisibility: true,
      trackVisibility: true,
      child: SingleChildScrollView(
        controller: _scrollController,
        child: Container(
          //need to containers, 1 to expand to full, second to triger max constrains
          alignment: Alignment.topCenter,
          width: double.infinity,
          padding: EdgeInsets.only(bottom: widget.bottomPadding),
          child: Container(
            //color: Colors.green,
            constraints: BoxConstraints(minWidth: widget.minWidth, maxWidth: widget.maxWidth),
            child: widget.child,
          ),
        ),
        //),
      ),
    );
  }

  Widget makeBody() {
    // debugPrint(widget.maxWidth);

    Widget ret = Container();

    if (widget.subTitles != null || widget.subTitleWidgets != null || widget.subTitleActions != null) {
      List<Widget> items = [
        MySubTitle(
          onNavBack: (widget.showBackButton) ? onSubmenuNavBack : null,
          text: widget.subTitles,
          titleWidgets: widget.subTitleWidgets,
          actionButtons: widget.subTitleActions,
        ),
        Divider(height: 1, thickness: 1),
        Expanded(child: makeCore()),
        //ret,
      ];

      ret = Column(children: items);
    } else {
      ret = makeCore();
    }

    if (widget.leftBodyContainer != null) {
      ret = Row(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          makeleftBodyContainer(),
          Expanded(child: ret),
        ],
      );
    }

    // double w = MediaQuery.of(context).size.width;
    // if (w > 1400) w = 1400;

    return Container(
      // color: Colors.blueAccent,
      width: MediaQuery.of(context).size.width,
      height: MediaQuery.of(context).size.height,
      constraints: BoxConstraints(minWidth: 500, minHeight: 500),
      child: ret,
    );
  }

  int _sideMenuItemsCount(String? parentID) {
    if (parentID == null) return 0;
    int ret = 0;

    return ret;
  }

  bool isBtnHomeVisible() {
    bool ret = false;
    if ((widget.showHomeButton)) {
      ret = true;
    }
    //debugPrint("MASTER TEMPLAET: " + ret.toString());
    return ret;
  }

  List<Widget> _makeActions() {
    List<Widget> arr = [];

    if (widget.topMenu != null) {
      arr.add(widget.topMenu!);
    }
    if (isBtnHomeVisible()) {
      arr.add(
        InkWell(
          hoverColor: Colors.black.withOpacity(0.3),
          onTap: () {
            //myApp.navigateBackHome();
          },
          child: Container(
            padding: EdgeInsets.fromLTRB(8, 0, 8, 0),
            child: Icon(Icons.apps, size: 42, color: _getTitleItemsColor()),
          ),
        ),
      );
    }

    if ((widget.showFeedbackButton)) {
      arr.add(
        IconButton(
          tooltip: ("Contact Support"),
          onPressed: () {
            Scaffold.of(context).openEndDrawer();
            //setContextWidget(FeedbackScreen(onClose: removeContextWidget));
          },
          icon: Icon(Icons.contact_support),
        ),
      );
    }

    return arr;
  }

  bool _showSideMenu() {
    bool ret = false;
    if (widget.showLeftMenu && _sideMenuItemsCount(menuParentID) > 0) {
      ret = true;
    } else if (widget.showLeftMenu && widget.sideMenu != null) {
      ret = true;
    }

    return ret;
  }

  Widget makePage() {
    //DO NOT SET tmplMasterScaffoldStateKey HERE - causes all widgets to force rerender every time when window is resized
    // myApp.tmplMasterScaffoldStateKey = GlobalKey<ScaffoldState>();
    Widget ret = Scaffold(
      key: currentScaffoldStateKey,
      appBar: AppBar(
        automaticallyImplyLeading: _showSideMenu(),
        backgroundColor: titleBgrColor,
        title: Row(children: lwTitle),
        actions: _makeActions(),
      ),

      body: makeBody(),
      //persistentFooterButtons: [],
      floatingActionButton: widget.floatButton,
      floatingActionButtonLocation: FloatingActionButtonLocation.endFloat,
    );

    if (_rightContainerFunction != null) {
      ret = Material(
        child: Row(
          children: [
            Expanded(child: ret),
            makeRightContainer(),
          ],
        ),
      );
    }

    return ret;
  }

  @override
  Widget build(BuildContext context) {
    return PopScope(
      canPop: widget.allowWillPop,
      child: Title(
        color: Colors.blue, // This is required
        title: ((widget.subTitles != null) ? widget.subTitles!.join(" / ") : ""),
        child: makePage(),
      ),
    );
  }
}

//

//

//

//

//

//

// ------------------- MasterTemplateFunctions

class MasterTemplateFunctions {
  Function(Widget)? _setContext;
  Function()? _removeContext;

  showSideFunction(Widget val) {
    if (_setContext != null) _setContext!(val);
  }

  hideSideFunction() {
    if (_removeContext != null) _removeContext!();
  }
}

//

//

//

//-------------------- MySubTitle

class MySubTitle extends StatelessWidget {
  final List<String>? text;
  final Function()? onNavBack;
  final List<Widget>? titleWidgets;
  final List<Widget>? actionButtons;

  MySubTitle({this.text, this.onNavBack, this.actionButtons, this.titleWidgets});

  List<Widget> makeItems() {
    List<Widget> ret = [];
    //print("onNavBack");
    //print(onNavBack);
    if (onNavBack != null) ret.add(IconButton(onPressed: onNavBack, icon: Icon(Icons.arrow_back)));
    ret.add(Container(width: 12)); // spacer

    if (titleWidgets != null) {
      titleWidgets!.forEach((el) {
        ret.add(Container(width: 12)); // spacer
        ret.add(el);
      });
    }

    if (actionButtons != null) {
      actionButtons!.forEach((el) {
        ret.add(Container(width: 12)); // spacer
        ret.add(el);
      });
    }

    return ret;
  }

  @override
  Widget build(BuildContext context) {
    return Container(
      padding: EdgeInsets.fromLTRB(12, 0, 28, 0),
      height: 56,
      width: double.infinity,
      child: Row(children: makeItems()),
    );
  }
}
