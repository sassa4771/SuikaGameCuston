<?php

// データベース接続情報
$servername = "127.0.0.1";
$username = "ekairo_sassa";
$password = "31314124Sassa";
$dbname = "ekairo_suikagamecuston";

// ユーザーからのPOSTデータを取得
$userName = $_POST['userName'];
$score = $_POST['score'];

// データベースに接続
$conn = new mysqli($servername, $username, $password, $dbname);

// 接続をチェック
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

// データを挿入するSQLクエリを作成して実行
$sql = "INSERT INTO score (userName, score) VALUES ('$userName', '$score')";

if ($conn->query($sql) === TRUE) {
    echo "Score inserted successfully";
} else {
    echo "Error: " . $sql . "<br>" . $conn->error;
}

// 接続を閉じる
$conn->close();
?>
