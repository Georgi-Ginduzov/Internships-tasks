import 'package:testapp/Modules/AccountRegister/AccountRegisterScreen.dart';

import 'package:flutter/foundation.dart';

import 'package:flutter/material.dart';

import 'App/IdiomRegister.dart';

void main() {
  if (kReleaseMode) {
    //kills debug print
    debugPrint = (dynamic message, {int? wrapWidth}) {};
  }

  WidgetsFlutterBinding.ensureInitialized();

  IdiomRegisterInit();
  runApp(App());
}

class App extends StatelessWidget {
  MaterialApp makeApp() {
    return MaterialApp(
      title: "App", // will set title later
      // localizationsDelegates: [
      //   GlobalMaterialLocalizations.delegate,
      //   GlobalWidgetsLocalizations.delegate,
      //   GlobalCupertinoLocalizations.delegate,
      // ],
      supportedLocales: const [
        Locale('en', ''), // English, no country code
        Locale('bg', ''), // Spanish, no country code
      ],
      //onGenerateRoute: r.generateRoute,
      theme: ThemeData(
        useMaterial3: false,
        // This is the theme of your application.
        //
        // Try running your application with "flutter run". You'll see the
        // application has a blue toolbar. Then, without quitting the app, try
        // changing the primarySwatch below to Colors.green and then invoke
        // "hot reload" (press "r" in the console where you ran "flutter run",
        // or simply save your changes to "hot reload" in a Flutter IDE).
        // Notice that the counter didn't reset back to zero; the application
        // is not restarted.
        primarySwatch: Colors.blue,
      ),
      darkTheme: ThemeData.dark(),
      themeMode: ThemeMode.system,
      home: AccountRegisterScreen(),
    );
  }

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return makeApp();
  }
}

class MyWidget extends StatefulWidget {
  const MyWidget({super.key});

  @override
  State<MyWidget> createState() => _MyWidgetState();
}

class _MyWidgetState extends State<MyWidget> {
  @override
  void initState() {
    super.initState();
    WidgetsBinding.instance.addPostFrameCallback((_) {
      //myApp.context = context;
      //myApp.appInitFinished();
      //MyGlobalEvents.initAppFinished.dispatch(null);
      // if (myApp.isInitFinished) {
      //   // if app init is done just start navigation - usualy web inits faster
      //   debugPrint("Fast Start");
      //   myApp.startNavigation();
      // } else {
      //   // wait for the app to finish init - usualy app is slower to init
      //   debugPrint("Slow Start");
      //   // call  myApp.startNavigation(); in myApp.initFinished
      // }
    });
  }

  @override
  Widget build(BuildContext context) {
    return Container();
  }
}
