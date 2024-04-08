import 'dart:async';
import 'dart:math';

import 'package:flutter/material.dart';
import 'package:flutter/services.dart';

import 'dart:convert';

class Tools {
  static bool intToBool(int? a, bool ifNull) {
    if (a == null) {
      return ifNull;
    }
    return a == 1 ? true : false;
  }

// reeds only JSON with single array structure []
  static Future<List<dynamic>> loadJsonAsset(String path) {
    Completer<List<dynamic>> completer = Completer<List<dynamic>>();

    rootBundle.loadString(path).then((value) {
      var t = json.decode(value);
      completer.complete(t);
    });

    return completer.future;
  }

  static String toBase64(String val) {
    var bytes = utf8.encode(val);
    return base64Encode(bytes);
  }

  static String fromBase64(String val) {
    var bytes = base64Decode(val);
    return utf8.decode(bytes);
  }

  static String newGuid() {
    var rnd = Random(DateTime.now().millisecond);

    String hexDigits = "0123456789abcdef";
    List<String> uid = [];

    for (int i = 0; i < 36; i++) {
      int hexPos = rnd.nextInt(16);
      uid.add(hexDigits.substring(hexPos, hexPos + 1));
    }

    int p = (int.parse(uid[19], radix: 16) & 0x3) | 0x8;

    uid[19] = hexDigits.substring(p, p + 1);

    uid[8] = uid[13] = uid[18] = uid[23] = "-";

    StringBuffer buffer = StringBuffer();
    buffer.writeAll(uid);

    return buffer.toString();
  }

//end tools
}

class CurvePainter extends CustomPainter {
  @override
  void paint(Canvas canvas, Size size) {
    wave1(canvas, size);
    wave2(canvas, size);
  }

  wave1(Canvas canvas, Size size) {
    var paint = Paint();
    paint.color = Colors.blue;
    paint.style = PaintingStyle.fill;

    var path = Path();

    path.moveTo(0, 50);
    path.quadraticBezierTo(size.width * 0.5, 180, size.width, 60);
    //path.quadraticBezierTo(size.width * 0.75, 160, size.width, 50);
    //path.quadraticBezierTo(size.width * 0.75, size.height * 0.9584, size.width * 1.0, size.height * 0.9167);
    path.lineTo(size.width, size.height);
    path.lineTo(0, size.height);

    canvas.drawPath(path, paint);
  }

  wave2(Canvas canvas, Size size) {
    var paint = Paint();
    paint.color = Colors.red.shade700;
    paint.style = PaintingStyle.fill;

    var path = Path();

    path.moveTo(0, 100);
    path.quadraticBezierTo(size.width * 0.25, 160, size.width * 0.5, 100);
    path.quadraticBezierTo(size.width * 0.75, 60, size.width, 140);
    //path.quadraticBezierTo(size.width * 0.75, size.height * 0.9584, size.width * 1.0, size.height * 0.9167);
    path.lineTo(size.width, size.height);
    path.lineTo(0, size.height);

    canvas.drawPath(path, paint);
  }

  @override
  bool shouldRepaint(CustomPainter oldDelegate) {
    return true;
  }
}
