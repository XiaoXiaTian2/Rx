# Rx

## 待改進

1. **`Subject.Complete` 沒有通知觀察者**：`Complete()` 只有 `_observers.Clear();`，沒有先對每個 observer 呼叫 `OnComplete()`。結果是訂閱時傳入的 `onCompleted` 永遠不會被執行，訂閱者無從得知資料流已經結束。修正方向：先 `foreach` 呼叫 `OnComplete()` 再清空清單。
2. **在 `onNext` 裡取消訂閱會拋出例外**：`Subject.Next` 用 `foreach` 走訪 `_observers`，如果某個 `onNext` 裡呼叫了 `Unsubcribe()`（例如「收到第一筆就取消」），`Remove` 會修改正在走訪的 `List`，下一次迭代就拋出 `InvalidOperationException`。這個例外發生在 `foreach` 取下一個元素時，不在 `try` 範圍內，會直接中斷 `Next`。修正方向：走訪前先複製一份清單，例如 `foreach (var observer in _observers.ToList())`。
3. **沒有提供 `onError` 時例外會被默默吞掉**：`Next` 捕捉到例外後呼叫 `observer.OnError(e.Message)`，而 `Observer.OnError` 是 `Error?.Invoke(e)`。只傳 `onNext` 的訂閱者（例如範例中的 `subscriptionA`）出錯時什麼事都不會發生，除錯時很難發現。修正方向：沒有 `onError` 時重新拋出，或至少記錄下來。
