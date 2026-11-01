# SOLID — Nguyên lý thiết kế hướng đối tượng

SOLID là chữ viết tắt của năm nguyên lý:

| Chữ | Nguyên lý | Ý chính |
|---|---|---|
| **S** | **Single Responsibility Principle (SRP)** — Đơn trách nhiệm | Một thành phần nên có một trách nhiệm chính, tương ứng với một nhóm lý do để thay đổi. |
| **O** | **Open/Closed Principle (OCP)** — Đóng/mở | Nên mở rộng hành vi bằng cách thêm thành phần mới, hạn chế phải sửa logic đã ổn định. |
| **L** | **Liskov Substitution Principle (LSP)** — Thay thế Liskov | Có thể thay đối tượng kiểu cơ sở bằng đối tượng kiểu dẫn xuất mà không phá vỡ hợp đồng hành vi. |
| **I** | **Interface Segregation Principle (ISP)** — Phân tách interface | Client không nên bị buộc phụ thuộc vào những phương thức mà nó không sử dụng. |
| **D** | **Dependency Inversion Principle (DIP)** — Đảo ngược phụ thuộc | Module cấp cao và cấp thấp nên phụ thuộc vào abstraction; abstraction không phụ thuộc vào chi tiết triển khai. |

Các nguyên lý này là hướng dẫn để cân nhắc thiết kế, không phải quy tắc yêu cầu tạo interface hoặc tách class trong mọi trường hợp. Hãy áp dụng khi chúng giúp giảm phụ thuộc và giới hạn ảnh hưởng của thay đổi.

## Tài liệu và ví dụ

| Nguyên lý | Tài liệu | Ví dụ C# |
|---|---|---|
| SRP | [Single Responsibility Principle](single-responsibility-principle/README.md) | [Program.cs](single-responsibility-principle/Program.cs) |
| OCP | [Open/Closed Principle](open-closed-principle/README.md) | [Program.cs](open-closed-principle/Program.cs) |
| LSP | [Liskov Substitution Principle](liskov-substitution-principle/README.md) | [Program.cs](liskov-substitution-principle/Program.cs) |
| ISP | [Interface Segregation Principle](interface-segregation-principle/README.md) | [Program.cs](interface-segregation-principle/Program.cs) |
| DIP | [Dependency Inversion Principle](dependency-inversion-principle/README.md) | [Program.cs](dependency-inversion-principle/Program.cs) |

## Cấu trúc thư mục

Mỗi nguyên lý có một thư mục riêng chứa README, chương trình minh họa và file project `.csproj`. [Solid.slnx](Solid.slnx) tập hợp cả năm project để mở và quản lý trong cùng một solution.

```text
SOLID/
├── single-responsibility-principle/
├── open-closed-principle/
├── liskov-substitution-principle/
├── interface-segregation-principle/
├── dependency-inversion-principle/
└── Solid.slnx
```

## Chạy ví dụ

Cài đặt .NET SDK 10, sau đó chạy một ví dụ bằng lệnh tương ứng:

```bash
dotnet run --project single-responsibility-principle/single-responsibility-principle.csproj
dotnet run --project open-closed-principle/open-closed-principle.csproj
dotnet run --project liskov-substitution-principle/liskov-substitution-principle.csproj
dotnet run --project interface-segregation-principle/interface-segregation-principle.csproj
dotnet run --project dependency-inversion-principle/dependency-inversion-principle.csproj
```

Có thể mở toàn bộ solution bằng IDE hỗ trợ .NET hoặc build từ thư mục gốc:

```bash
dotnet build Solid.slnx
```

## Tài liệu tham khảo

- Robert C. Martin, [Design Principles and Design Patterns](https://objectmentor.com/resources/articles/Principles_and_Patterns.pdf) — bài viết về các nguyên lý và mẫu thiết kế hướng đối tượng.
- Barbara Liskov, [Data Abstraction and Hierarchy](https://doi.org/10.1145/62138.62141) — tài liệu nền tảng về abstraction và quan hệ phân cấp kiểu liên quan đến LSP.
- Microsoft Learn, [Object-oriented programming in C#](https://learn.microsoft.com/dotnet/csharp/fundamentals/tutorials/oop) — kiến thức nền về lập trình hướng đối tượng trong C#.
- Microsoft Learn, [Dependency injection guidelines for .NET](https://learn.microsoft.com/dotnet/core/extensions/dependency-injection-guidelines) — hướng dẫn DI trong .NET; DI là kỹ thuật thường dùng để cung cấp dependency và có liên hệ với cách triển khai DIP.
