<?php

// データベース接続情報
$servername = "127.0.0.1";
$username = "ekairo_sassa";
$password = "31314124Sassa";
$dbname = "ekairo_suikagamecuston";

// データベースに接続
$conn = new mysqli($servername, $username, $password, $dbname);

// 接続をチェック
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

// SQLクエリを構築して実行
$sql = "SELECT userName, score FROM score ORDER BY score DESC LIMIT 4";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
    $data = array(
        "firstRank" => array(),
        "secondRank" => array(),
        "thirdRank" => array(),
        "forthRank" => array()
    );

    // 結果からデータを取得して配列に追加
    $count = 0;
    while ($row = $result->fetch_assoc()) {
        switch ($count) {
            case 0:
                $data["firstRank"] = array(
                    "userName" => $row['userName'],
                    "score" => $row['score']
                );
                break;
            case 1:
                $data["secondRank"] = array(
                    "userName" => $row['userName'],
                    "score" => $row['score']
                );
                break;
            case 2:
                $data["thirdRank"] = array(
                    "userName" => $row['userName'],
                    "score" => $row['score']
                );
                break;
            case 3:
                $data["forthRank"] = array(
                    "userName" => $row['userName'],
                    "score" => $row['score']
                );
                break;
            default:
                break;
        }
        $count++;
    }

    // JSON形式にエンコードして出力
    $json_output = json_encode($data);
    echo $json_output;
} else {
    echo "0 results";
}

// 接続を閉じる
$conn->close();
?>
