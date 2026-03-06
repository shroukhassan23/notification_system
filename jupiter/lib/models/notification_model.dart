class NotificationModel {
  final int id;
  final String title;
  final String body;
  final DateTime createdAt;
  final String sentBy;
  final bool isSent;

  NotificationModel({
    required this.id,
    required this.title,
    required this.body,
    required this.createdAt,
    required this.sentBy,
    required this.isSent,
  });

  factory NotificationModel.fromJson(Map<String, dynamic> json) {
    return NotificationModel(
      id: json['id'],
      title: json['title'],
      body: json['body'],
      createdAt: DateTime.parse(json['createdAt']),
      sentBy: json['sentBy'],
      isSent: json['isSent'],
    );
  }
}
