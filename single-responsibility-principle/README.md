# Single Responsibility Principle (SRP)

## 1. Khái niệm

Single Responsibility Principle (SRP) là nguyên tắc đầu tiên trong nhóm
SOLID, áp dụng trong thiết kế và phát triển phần mềm hướng đối tượng.

SRP phát biểu rằng:

> Một class chỉ nên có một lý do để thay đổi.

Nói cách khác, một class nên tập trung vào một trách nhiệm chính. Các
thành phần bên trong class cần liên quan đến cùng một nhóm chức năng.

Điều này **không có nghĩa là một class chỉ được có một method**. Một
class có thể có nhiều method nếu chúng cùng phục vụ một trách nhiệm.

Mục tiêu của SRP là giúp phần mềm dễ hiểu, linh hoạt và dễ bảo trì hơn.

## 2. Responsibility là gì?

Responsibility (trách nhiệm) là một nhóm chức năng hoặc công việc mà một
thành phần trong hệ thống đảm nhiệm.

Trong một ứng dụng, các trách nhiệm có thể bao gồm:

-   Truy xuất và quản lý dữ liệu.
-   Kiểm tra tính hợp lệ của dữ liệu.
-   Xác thực người dùng.
-   Ghi log.
-   Caching.
-   Chuyển đổi hoặc tuần tự hóa dữ liệu.
-   Xử lý nghiệp vụ.
-   Gửi email hoặc thông báo.

Khi một nhóm chức năng thay đổi, class chịu trách nhiệm cho nhóm chức
năng đó thường là nơi cần được thay đổi.

## 3. Cách áp dụng SRP

### Bước 1: Xác định các trách nhiệm

Phân tích chức năng của class và xác định những nhóm công việc mà class
đang đảm nhiệm.

### Bước 2: Tách các trách nhiệm độc lập

Nếu một class đang xử lý nhiều nhóm chức năng không cùng mục đích, cân
nhắc tách chúng thành các class riêng biệt.

### Bước 3: Phân chia trách nhiệm rõ ràng

Mỗi class chỉ nên tập trung vào một nhiệm vụ chính. Các class có thể
phối hợp với nhau, nhưng không nên sở hữu hoặc xử lý thay trách nhiệm
của nhau.

## 4. Dấu hiệu vi phạm SRP

Một class có thể đang vi phạm SRP khi nó đồng thời đảm nhiệm nhiều công
việc độc lập, chẳng hạn:

-   Xử lý nghiệp vụ chính.
-   Ghi log lỗi.
-   Gửi email.
-   Định dạng hoặc hiển thị dữ liệu.

Khi các trách nhiệm này cùng nằm trong một class, thay đổi ở một chức
năng có thể buộc phải sửa class đó dù nghiệp vụ chính không thay đổi.

### Hệ quả

-   Khó đọc và khó hiểu vì class có quá nhiều mối quan tâm.
-   Khó kiểm thử từng chức năng độc lập.
-   Thay đổi một chức năng có thể ảnh hưởng đến các chức năng khác.
-   Dễ phát sinh logic trùng lặp.
-   Khó bảo trì và mở rộng.

## 5. Thiết kế theo SRP

Thay vì để một class xử lý toàn bộ công việc, phân chia các trách nhiệm
thành những thành phần riêng:

-   **Invoice**: xử lý các nghiệp vụ liên quan đến hóa đơn.
-   **Logger**: đảm nhiệm việc ghi log.
-   **MailSender**: đảm nhiệm việc gửi email.

Class nghiệp vụ chính có thể sử dụng các thành phần hỗ trợ, nhưng không
trực tiếp sở hữu logic chi tiết của việc ghi log hoặc gửi email.

### Sơ đồ: Thiết kế chưa tách trách nhiệm

``` mermaid
flowchart TD
    A["Invoice"] --> B["Xử lý hóa đơn"]
    A --> C["Ghi log"]
    A --> D["Gửi email"]
    style A fill:#FEE2E2,stroke:#DC2626,color:#111827
```

### Sơ đồ: Thiết kế tách trách nhiệm theo SRP

``` mermaid
flowchart TD
    A["Invoice"] --> B["Nghiệp vụ hóa đơn"]
    A --> C["Logger"]
    A --> D["MailSender"]
    C --> E["Trách nhiệm ghi log"]
    D --> F["Trách nhiệm gửi email"]
    style A fill:#DBEAFE,stroke:#2563EB,color:#111827
    style C fill:#DCFCE7,stroke:#16A34A,color:#111827
    style D fill:#DCFCE7,stroke:#16A34A,color:#111827
```

## 6. Vai trò của interface và việc phân công trách nhiệm

Interface có thể được sử dụng để mô tả một hợp đồng cho một nhóm hành
vi. Những class triển khai interface sẽ cung cấp cách thực hiện các hành
vi đó.

Ví dụ về mặt thiết kế, một abstraction dành cho logging giúp phần nghiệp
vụ phụ thuộc vào hợp đồng ghi log thay vì phụ thuộc trực tiếp vào cách
ghi log cụ thể.

Việc tách class không chỉ là chuyển method sang file khác. Quan trọng
hơn là xác định đúng trách nhiệm và giới hạn thay đổi của từng thành
phần.

## 7. Lợi ích của SRP

-   **Dễ hiểu:** Mỗi class có mục đích rõ ràng và phạm vi chức năng tập
    trung.
-   **Dễ thay đổi:** Thay đổi yêu cầu ở một trách nhiệm ít tác động đến
    các thành phần khác.
-   **Dễ kiểm thử:** Có thể kiểm thử từng nhóm chức năng độc lập.
-   **Tăng khả năng tái sử dụng:** Thành phần có trách nhiệm rõ ràng có
    thể được sử dụng ở nhiều nơi.
-   **Tổ chức code tốt hơn:** Cấu trúc hệ thống rõ ràng, thuận lợi cho
    bảo trì và phát triển.

## 8. Ghi nhớ

-   SRP không yêu cầu mỗi class chỉ có một method.
-   SRP yêu cầu mỗi class có một trách nhiệm chính, tương ứng với một lý
    do để thay đổi.
-   Không nên tách class một cách máy móc; cần dựa trên sự liên quan
    giữa các chức năng.
-   Các class có thể phối hợp với nhau, nhưng mỗi class cần giữ đúng
    trách nhiệm của mình.
-   Mục tiêu cuối cùng là giảm sự phụ thuộc không cần thiết và giới hạn
    phạm vi ảnh hưởng khi hệ thống thay đổi.
