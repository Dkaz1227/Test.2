# LAB 5: NT106.Q14 - Gửi và Nhận Email trong C#

Tài liệu hướng dẫn và bài tập thực hành Lab 5 môn Lập trình mạng căn bản tại UIT.

- **Lớp học:** NT106.Q14
- **Giáo viên hướng dẫn:** ThS. Lê Minh Khánh Hội

## THÔNG TIN CÁC THÀNH VIÊN
| Tên thành viên   |      MSSV      |
|------------------|:--------------:|
| Nguyễn Nhật Anh  |   24520112     |
| Nguyễn Hoàng Anh  |   24520102     |
| Huỳnh Hoàng Tứ Văn |   24521977     |
| Trần Huy Vũ      |   24522043     |
| Lê Nguyễn Phương Vy |   24522056     |

## Mục tiêu bài học
* Nắm được cách giao tiếp với Email Server thông qua các giao thức:
    * **SMTP (Port 25/465):** Giao thức dùng để gửi mail.
    * **POP3 (Port 110/995):** Giao thức truy xuất mail, phù hợp khi dùng trên một thiết bị duy nhất.
    * **IMAP (Port 143/993):** Giao thức truy xuất mail hiện đại, hỗ trợ đồng bộ trên nhiều thiết bị.
* Sử dụng thư viện System.Net.Mail và các thư viện hỗ trợ như MailKit/MimeKit để lập trình ứng dụng Email Client.

## Yêu cầu chuẩn bị
* **Phần mềm:** Visual Studio 2022 (Workload: .NET desktop development).
* **Tài khoản Email:** Sử dụng Gmail cần tạo App Password để xác thực.
* **Cấu hình Server (Gmail):**
    * SMTP: smtp.gmail.com | Port: 465 (SSL).
    * IMAP: imap.gmail.com | Port: 993 (SSL).
    * POP3: pop.gmail.com | Port: 995 (SSL).

## Danh sách các bài tập

| Bài | Tên Project | Mô tả | Công cụ chính |
| :--- | :--- | :--- | :--- |
| **Bài 1** | **SendEmailBasic** | Ứng dụng gửi mail đơn giản với các trường: From, To, Subject, Body. | SmtpClient, NetworkCredential |
| **Bài 2** | **ReadEmailIMAP** | Đăng nhập và hiển thị danh sách email (Subject, From, Date) từ Inbox qua IMAP. | ImapClient |
| **Bài 3** | **ReadEmailPOP3** | Tương tự bài 2 nhưng sử dụng giao thức POP3 để đọc mail. | Pop3Client |
| **Bài 4** | **TicketManager_v5** | Quản lý phòng vé: Gửi email xác nhận kèm vé và Poster phim cho khách hàng sau khi đặt thành công. | SmtpClient, HTML Body |
| **Bài 5** | **HomNayAnGi_v5** | Ứng dụng đóng góp món ăn qua Email: Tải các đóng góp từ Email cộng đồng vào Database. | IMAP/POP3, SQL Database |
| **Bài 6** | **EmailClient_Pro** | Xây dựng ứng dụng Email Client hoàn chỉnh: Đăng nhập/xuất, gửi mail (kèm đính kèm), Reply và duyệt mail. | Tổng hợp SMTP/IMAP/POP3 |

## Hướng dẫn chạy đồ án
1. Clone repository: `git clone https://github.com/SPdream99/NT106-LAB5/`
2. Mở file solution: `Lab05.slnx` (hoặc `.sln`).
3. Chuẩn bị App Password cho Gmail cá nhân để test các chức năng gửi/nhận.
4. Chuột phải vào Project cần chạy -> **Set as Startup Project**.
5. Nhấn **F5** để bắt đầu Debug.

## Tài liệu tham khảo
* Microsoft .NET Mail Documentation
* [Tài liệu C#](https://docs.microsoft.com/en-us/dotnet/csharp/)
* [Tài liệu Winforms](https://learn.microsoft.com/vi-vn/dotnet/desktop/winforms/)
* Tài liệu của giáo viên cung cấp trong lớp NT106.Q14

### CC BY-NC 4.0
