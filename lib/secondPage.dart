import 'dart:developer';

import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_unity_widget/flutter_unity_widget.dart';

class UnityTestingWrapper extends StatefulWidget {
  UnityTestingState createState() => UnityTestingState();
}

class UnityTestingState extends State<UnityTestingWrapper> {
  late UnityWidgetController _unityWidgetController;

  @override
  void dispose() {
    _unityWidgetController.unload();
    _unityWidgetController.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      home: Scaffold(
        appBar: AppBar(
          title: const Text('Unity Flutter Demo'),
        ),
        body: Card(
          margin: const EdgeInsets.all(8),
          clipBehavior: Clip.antiAlias,
          shape: RoundedRectangleBorder(
            borderRadius: BorderRadius.circular(20.0),
          ),
          child: UnityWidget(
            onUnityCreated: _onUnityCreated,
            borderRadius: BorderRadius.circular(20.0),
            fullscreen: false,
          ),
        ),
      ),
    );
  }

  void _onUnityCreated(UnityWidgetController controller) async {
    this._unityWidgetController = controller;
    controller.unload();
    controller.dispose();
    await controller.create();
    await controller.resume();
    log((await controller.isPaused()).toString());
    log((await controller.isLoaded()).toString());
    log((await controller.isReady()).toString());
  }
}
