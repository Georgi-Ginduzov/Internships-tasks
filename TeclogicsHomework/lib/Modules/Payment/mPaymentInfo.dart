class MPaymentInfo {
  String? number = "";
  String? expYear = "";
  String? expMonth = "pencho";
  String? cvc = "";
  String? name = "";
  String currency = "";
  String? amount = "";

  Address address = Address();

  String? billingAddress;
  String? billingCity;
  String? billingState;
  String? billingZip;

  MPaymentInfo();

  Map<String, dynamic> toMap() {
    Map<String, dynamic> ret = {
      'number': number,
      'expYear': expYear,
      'expMonth': expMonth,
      'cvc': cvc,
      'name': name,
      'currency': currency,
      'amount': amount,
      'address': address.toMap(),
    };

    return ret;
  }

  // End Class MAccountRegister
}

class Address {
  String region = "";
  String postalCode = "";
  String streetAddress = "";
  String country = "US";
  String city = "South Orange";

  Map<String, dynamic> toMap() {
    Map<String, dynamic> ret = {
      'region': region,
      'postalCode': postalCode,
      'streetAddress': streetAddress,
      'country': country,
      'city': city,
    };

    return ret;
  }
}
