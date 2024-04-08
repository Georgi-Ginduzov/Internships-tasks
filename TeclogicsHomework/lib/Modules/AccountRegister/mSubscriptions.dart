class MSubscription {
  int sort;
  String id;
  String name;
  double price;
  String description;
  int amount = 0;

  MSubscription({
    required this.sort,
    required this.id,
    required this.name,
    required this.price,
    required this.description,
  });

  factory MSubscription.fromMap(Map<String, dynamic> map) {
    return MSubscription(
      sort: map['Sort'],
      id: map['ID'],
      name: map['Name'],
      price: map['Price'],
      description: map['Description'],
    );
  }

  Map<String, dynamic> toMap() {
    final Map<String, dynamic> data = {
      'Sort': this.sort,
      'ID': this.id,
      'Name': this.name,
      'Price': this.price, // Convert to cents
      'Description': this.description,
    };
    return data;
  }
}
