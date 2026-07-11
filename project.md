# Project.md — Personal Life OS / Finance-first Life Management App

## 1. Tên dự án

Tên tạm thời:

```txt
Personal Life OS
Finance-first Life Management App
Life Dashboard
Personal Management System
```

Tên kỹ thuật có thể dùng trong code:

```txt
PersonalLifeOS
LifeOS
FinLife
```

---

## 2. Mô tả ngắn gọn

Dự án ban đầu là một ứng dụng quản lý tài chính cá nhân, giúp người dùng theo dõi thu nhập, chi tiêu, ví/tài khoản, ngân sách, mục tiêu tiết kiệm và báo cáo tài chính.

Về lâu dài, dự án sẽ mở rộng thành một hệ thống quản lý đời sống cá nhân toàn diện, kết nối tài chính với mục tiêu, công việc, thói quen, lịch, review cá nhân và AI insight.

Ý tưởng cốt lõi:

```txt
Không chỉ ghi lại người dùng đã tiêu gì,
mà giúp người dùng hiểu tiền bạc, quản lý mục tiêu,
sắp xếp hành động và ra quyết định sống tốt hơn mỗi ngày.
```

Định vị sản phẩm:

```txt
Một Personal Life OS bắt đầu từ quản lý tài chính.
```

Hoặc:

```txt
Một hệ thống cá nhân giúp kết nối tiền bạc, thời gian, mục tiêu và thói quen để người dùng quản lý cuộc sống có định hướng hơn.
```

---

## 3. Vấn đề cần giải quyết

Người dùng thường gặp các vấn đề sau:

1. Không biết tiền của mình đang đi đâu.
2. Phải nhập giao dịch thủ công, gây bất tiện và dễ bỏ cuộc.
3. Có mục tiêu nhưng không biết phải tiết kiệm bao nhiêu, làm gì mỗi ngày, hoặc đang chậm tiến độ như thế nào.
4. Todo list, habit tracker, finance app, calendar thường tách rời nhau.
5. Các app ghi chép tài chính thường chỉ nhìn lại quá khứ, chưa giúp người dùng ra quyết định cho tương lai.
6. Người dùng không biết hôm nay mình có thể tiêu bao nhiêu mà vẫn không ảnh hưởng đến mục tiêu.
7. Người dùng không có một dashboard cá nhân để biết hôm nay cần chú ý điều gì.
8. Người dùng muốn có AI cá nhân, nhưng AI chỉ thật sự hữu ích khi có dữ liệu cá nhân đủ tốt và được tổ chức đúng cách.

---

## 4. Tầm nhìn dài hạn

Dự án không chỉ là app tài chính cá nhân.

Tầm nhìn dài hạn là xây dựng một hệ thống giúp người dùng trả lời 4 câu hỏi lớn:

```txt
Tiền của mình đang đi đâu?
Thời gian của mình đang dùng vào việc gì?
Mục tiêu của mình đang tiến triển thế nào?
Thói quen hằng ngày có đang kéo mình lại gần cuộc sống mình muốn không?
```

Hệ thống sẽ dần trở thành một “trợ lý đời sống cá nhân” dựa trên dữ liệu thật của người dùng.

---

## 5. Nguyên tắc sản phẩm

### 5.1. Dashboard-first

Người dùng không nên phải tự hỏi app mọi thứ.

App cần chủ động hiển thị những thông tin quan trọng:

```txt
Hôm nay còn có thể tiêu bao nhiêu?
Goal nào đang chậm?
Task nào quan trọng?
Habit nào cần duy trì?
Khoản chi nào bất thường?
Hóa đơn nào sắp đến hạn?
```

### 5.2. Insight-first

AI không nên chỉ là một chatbot trống.

App cần tự phân tích dữ liệu và tạo các insight card như:

```txt
Chi tiêu ăn ngoài tăng 42% so với tháng trước.
Goal “Mua laptop” đang chậm 4 ngày.
Bạn đã order đồ ăn 4 lần tuần này, vượt mục tiêu 1 lần.
Nếu giữ tốc độ chi tiêu hiện tại, cuối tháng bạn sẽ vượt budget 1.200.000đ.
```

### 5.3. Action-first

Mỗi insight nên có hành động đi kèm:

```txt
Tạo task
Tạo budget
Tạo saving goal
Tạo challenge
Điều chỉnh mục tiêu
Hỏi AI thêm
Bỏ qua insight
```

### 5.4. Chat-optional

Chat AI chỉ là một lớp phụ trợ.

UI chính không nên clone ChatGPT.

AI nên là bộ não chạy phía sau, còn giao diện chính vẫn là dashboard, module quản lý, insight center và action flow.

### 5.5. Privacy-first

Dữ liệu tài chính và đời sống cá nhân rất nhạy cảm.

Dự án nên ưu tiên:

```txt
Dữ liệu thuộc về người dùng
Có thể export dữ liệu
Không bán dữ liệu
Có cơ chế xóa tài khoản/xóa dữ liệu
Có thể thiết kế local-first hoặc private mode trong tương lai
```

---

## 6. Đối tượng người dùng ban đầu

Ban đầu, sản phẩm được xây dựng cho chính chủ dự án sử dụng cá nhân.

Nhóm người dùng tiềm năng sau này:

```txt
Sinh viên muốn quản lý chi tiêu
Người mới đi làm muốn kiểm soát tài chính
Freelancer có thu nhập không cố định
Người muốn tiết kiệm cho mục tiêu cụ thể
Người muốn quản lý tài chính + task + habit trong một hệ thống duy nhất
Người thích self-improvement và quantified self
```

---

## 7. Điểm khác biệt so với app thông thường

Các app thông thường thường tách rời:

```txt
Finance app: quản lý tiền
Todo app: quản lý việc
Habit app: quản lý thói quen
Calendar app: quản lý thời gian
Note app: ghi chú/review
```

Dự án này khác ở chỗ kết nối các mảng đó lại:

```txt
Tiền bạc ↔ Mục tiêu ↔ Công việc ↔ Thói quen ↔ Thời gian ↔ Quyết định hằng ngày
```

Ví dụ:

```txt
Goal: Mua laptop 35 triệu
→ Saving goal: cần tiết kiệm 5.8 triệu/tháng
→ Budget: giảm ăn ngoài 600k/tháng
→ Task: so sánh laptop, tìm deal, bán máy cũ
→ Habit: không order đồ ăn quá 3 lần/tuần
→ AI insight: nếu giữ tốc độ hiện tại, goal sẽ chậm 9 ngày
```

---

## 8. Kiến trúc đề xuất

Nên sử dụng:

```txt
.NET Web API
Clean Architecture rút gọn
Modular Monolith
Entity Framework Core
SQL Server hoặc PostgreSQL
JWT Authentication
MediatR/CQRS nhẹ nếu cần
Background Job bằng Hangfire hoặc Quartz về sau
```

Không nên dùng microservices ở giai đoạn đầu.

Lý do:

```txt
Dự án cá nhân, một người làm
Cần phát triển nhanh nhưng vẫn dễ mở rộng
Nhiều module nghiệp vụ nhưng chưa cần tách service độc lập
Modular Monolith đủ sạch, dễ maintain, dễ deploy
```

---

## 9. Cấu trúc solution gợi ý

```txt
PersonalLifeOS.sln

src/
  PersonalLifeOS.Api/
  PersonalLifeOS.Application/
  PersonalLifeOS.Domain/
  PersonalLifeOS.Infrastructure/
  PersonalLifeOS.Shared/

tests/
  PersonalLifeOS.UnitTests/
  PersonalLifeOS.IntegrationTests/
```

### 9.1. PersonalLifeOS.Api

Chứa:

```txt
Controllers hoặc Minimal APIs
Authentication middleware
Authorization
Request/response endpoint mapping
Swagger/OpenAPI config
Exception middleware
API versioning nếu cần
```

### 9.2. PersonalLifeOS.Domain

Chứa logic nghiệp vụ cốt lõi, không phụ thuộc database/framework.

Ví dụ:

```txt
Entities
ValueObjects
Enums
Domain Events
Domain Services nếu cần
Business Rules
```

### 9.3. PersonalLifeOS.Application

Chứa use case của hệ thống.

Ví dụ:

```txt
Commands
Queries
Handlers
DTOs
Validators
Interfaces
Application services
```

### 9.4. PersonalLifeOS.Infrastructure

Chứa phần giao tiếp với thế giới bên ngoài:

```txt
EF Core DbContext
Repositories
External integrations
Bank webhook services
Email/notification services
AI provider services
File import parsers
Background jobs
```

### 9.5. PersonalLifeOS.Shared

Chứa các thành phần dùng chung:

```txt
Result pattern
Error codes
Constants
Common utilities
Pagination models
Date/time helpers
```

---

## 10. Module chính

Dự án nên được tổ chức theo module nghiệp vụ.

```txt
Finance
Goals
Tasks
Habits
Calendar
Review
Insights
AI
Notifications
Integrations
Identity
```

Giai đoạn đầu tập trung vào Finance trước.

---

# 11. Module Finance

## 11.1. Mục tiêu

Quản lý toàn bộ dữ liệu tài chính cá nhân của người dùng.

## 11.2. Chức năng chính

```txt
Quản lý ví/tài khoản
Quản lý giao dịch thu/chi/chuyển khoản
Quản lý danh mục thu/chi
Quản lý ngân sách tháng
Quản lý mục tiêu tiết kiệm
Quản lý khoản định kỳ
Import sao kê ngân hàng
Tự động nhận giao dịch qua webhook/API nếu có
Báo cáo chi tiêu
Dự báo cuối tháng
Safe-to-spend mỗi ngày
```

## 11.3. Entity gợi ý

```txt
Account
Transaction
TransactionCategory
Budget
BudgetPeriod
SavingGoal
RecurringTransaction
BankConnection
BankWebhookEvent
ImportSession
ImportRule
```

## 11.4. Transaction

Các trường gợi ý:

```txt
Id
UserId
AccountId
CategoryId
Amount
Type: Income / Expense / Transfer
Description
TransactionDate
Source: Manual / BankWebhook / CsvImport / Notification / AI
ExternalTransactionId
RawContent
Status: PendingReview / Confirmed / Ignored
CreatedAt
UpdatedAt
```

## 11.5. Transaction Source

Hệ thống cần hỗ trợ nhiều nguồn nhập giao dịch:

```txt
ManualInput
CsvImport
ExcelImport
BankWebhook
NotificationParser
EmailParser
AIExtraction
```

Không nên hard-code chỉ có nhập tay.

## 11.6. Auto Categorization

Ban đầu có thể làm rule-based:

```txt
Nếu nội dung chứa "GRAB" → Di chuyển hoặc Ăn uống
Nếu nội dung chứa "SHOPEE" → Mua sắm
Nếu nội dung chứa "NETFLIX" → Subscription
Nếu amount giống nhau hằng tháng → Recurring transaction
```

Về sau có thể dùng AI gợi ý category.

---

# 12. Module Banking Integration

## 12.1. Mục tiêu

Giảm bất tiện khi người dùng phải nhập giao dịch thủ công sau mỗi lần chuyển khoản.

## 12.2. Hướng tích hợp

Các hướng hỗ trợ:

```txt
Import CSV/Excel sao kê ngân hàng
Webhook/API qua provider trung gian
Đọc notification Android cho bản personal/private nếu cần
Email parser nếu ngân hàng gửi email biến động số dư
```

## 12.3. Không nên làm

Không nên:

```txt
Lưu username/password ngân hàng
Tự login Internet Banking
Scrape web/app ngân hàng
Đọc OTP
Can thiệp giao dịch ngân hàng
```

Lý do:

```txt
Rủi ro bảo mật
Dễ vi phạm điều khoản ngân hàng
Khó bảo trì
Không phù hợp nếu public sản phẩm
```

## 12.4. Webhook flow

```txt
Ngân hàng có biến động số dư
→ Provider gửi webhook về backend
→ Backend lưu raw event
→ Backend map sang Transaction
→ Check duplicate
→ Gán trạng thái PendingReview hoặc Confirmed
→ Gợi ý category
→ Người dùng confirm nếu cần
```

Endpoint gợi ý:

```txt
POST /api/integrations/bank-webhooks/casso
POST /api/integrations/bank-webhooks/sepay
POST /api/integrations/bank-webhooks/generic
```

---

# 13. Module Goals

## 13.1. Mục tiêu

Quản lý mục tiêu cá nhân và liên kết mục tiêu với tiền bạc, task, habit.

## 13.2. Chức năng

```txt
Tạo goal
Chia goal thành milestone
Theo dõi tiến độ
Liên kết goal với saving goal
Liên kết goal với task
Liên kết goal với habit
Cảnh báo goal bị chậm
AI gợi ý kế hoạch đạt goal
```

## 13.3. Entity gợi ý

```txt
Goal
GoalMilestone
GoalProgressLog
GoalLink
```

## 13.4. Ví dụ

```txt
Goal: Mua laptop 35 triệu trong 6 tháng
→ Saving goal: 35 triệu
→ Monthly target: 5.8 triệu/tháng
→ Tasks: so sánh máy, tìm deal, bán máy cũ
→ Habits: giảm order đồ ăn, review chi tiêu mỗi tuần
```

---

# 14. Module Tasks

## 14.1. Mục tiêu

Quản lý việc cần làm và liên kết với goal/lịch/habit.

## 14.2. Chức năng

```txt
Tạo task
Deadline
Priority
Status
Subtasks
Recurring task
Liên kết task với goal
Task hôm nay
Task quan trọng
Task overdue
```

## 14.3. Entity gợi ý

```txt
TaskItem
TaskList
TaskComment
TaskReminder
```

---

# 15. Module Habits

## 15.1. Mục tiêu

Quản lý thói quen hằng ngày/tuần và liên kết với tài chính hoặc goal.

## 15.2. Chức năng

```txt
Tạo habit
Check-in habit
Streak
Habit frequency
Habit linked to goal
Habit linked to finance rule
Habit report
```

## 15.3. Entity gợi ý

```txt
Habit
HabitLog
HabitRule
HabitStreak
```

## 15.4. Ví dụ đặc biệt

Habit có thể được xác thực bằng giao dịch tài chính.

Ví dụ:

```txt
Habit: Không order đồ ăn quá 3 lần/tuần
Nguồn dữ liệu: giao dịch GrabFood, ShopeeFood, BeFood, MoMo Food
Nếu tuần này phát hiện 4 giao dịch order đồ ăn → habit bị vượt limit
```

---

# 16. Module Calendar

## 16.1. Mục tiêu

Quản lý thời gian và lịch cá nhân.

## 16.2. Chức năng tương lai

```txt
Calendar events
Time blocking
Auto-plan task vào lịch
Nhắc deadline
Lịch review tuần/tháng
Tích hợp Google Calendar nếu cần
```

---

# 17. Module Review

## 17.1. Mục tiêu

Giúp người dùng nhìn lại tuần/tháng và điều chỉnh kế hoạch.

## 17.2. Weekly Review

App có thể tự tổng hợp:

```txt
Tuần này bạn tiêu bao nhiêu?
Khoản chi nào tăng bất thường?
Task hoàn thành bao nhiêu phần trăm?
Habit nào duy trì tốt?
Goal nào bị bỏ quên?
Tuần sau nên ưu tiên điều gì?
```

## 17.3. Monthly Review

App có thể tự tổng hợp:

```txt
Tổng thu
Tổng chi
Tỷ lệ tiết kiệm
Budget vượt/chưa vượt
Goal đạt/chậm
Habit consistency
Điểm mạnh/yếu trong tháng
Gợi ý tháng sau
```

---

# 18. Module Insights

## 18.1. Mục tiêu

Tạo insight chủ động từ dữ liệu cá nhân.

## 18.2. Insight examples

```txt
Chi tiêu ăn ngoài tăng 42% so với tháng trước.
Nếu giữ tốc độ chi tiêu hiện tại, cuối tháng bạn sẽ vượt budget 1.200.000đ.
Goal “Quỹ dự phòng” đang chậm 5 ngày.
Bạn đã order đồ ăn 4 lần tuần này, vượt limit 1 lần.
Có 2 subscription mới xuất hiện trong tháng này.
Task liên quan đến goal học tiếng Anh đã bị bỏ quên 10 ngày.
Bạn có 3 khoản định kỳ sắp đến hạn trong 5 ngày tới.
```

## 18.3. Insight status

```txt
New
Viewed
ActionTaken
Dismissed
Expired
```

## 18.4. Insight actions

```txt
CreateTask
CreateBudget
AdjustBudget
CreateSavingGoal
CreateHabit
StartChallenge
AskAI
Dismiss
```

---

# 19. Module AI

## 19.1. Vai trò của AI

AI trong dự án này không phải là UI chính.

AI là bộ não phân tích phía sau.

AI có 3 vai trò:

```txt
Phân tích thụ động
Gợi ý hành động
Trợ lý hội thoại có ngữ cảnh
```

## 19.2. Không nên làm ChatGPT clone

Không nên thiết kế app mà màn hình chính chỉ là một ô chat.

Lý do:

```txt
Người dùng không biết phải hỏi gì
App sẽ trống nếu chưa có dữ liệu
Giá trị sản phẩm không rõ
Không tận dụng dashboard/insight/action flow
```

## 19.3. UI đúng hơn

```txt
Dashboard-first
Insight-first
Action-first
Chat-optional
```

## 19.4. AI Context Layer

Không dump toàn bộ database vào prompt.

Cần có lớp lấy ngữ cảnh phù hợp.

Ví dụ người dùng hỏi:

```txt
Tôi có nên mua tai nghe 3 triệu không?
```

Hệ thống chỉ lấy dữ liệu liên quan:

```txt
Số dư hiện tại
Budget mua sắm tháng này
Saving goal đang chạy
Chi tiêu tháng này
Khoản định kỳ sắp tới
Lịch sử mua đồ công nghệ
```

Sau đó mới đưa cho AI phân tích.

## 19.5. AI flow

```txt
User question hoặc background insight job
→ Intent detection
→ Retrieve relevant context
→ Build prompt
→ AI reasoning
→ Return answer/insight/action suggestions
→ User confirms action if data will be changed
```

## 19.6. AI không tự ý sửa dữ liệu

AI có thể đề xuất:

```txt
Tạo task
Tạo budget
Tạo habit
Điều chỉnh goal
Tạo challenge
```

Nhưng cần người dùng xác nhận trước khi thay đổi dữ liệu quan trọng.

---

# 20. Các tính năng nổi bật nên có

## 20.1. Safe-to-spend

Mục tiêu:

Cho người dùng biết hôm nay còn có thể tiêu bao nhiêu mà vẫn không ảnh hưởng đến budget và goal.

Ví dụ:

```txt
Từ giờ đến cuối tháng còn 12 ngày.
Sau khi trừ tiền nhà, tiền ăn, subscription và saving goal,
mỗi ngày bạn còn có thể tiêu khoảng 185.000đ.
```

Dashboard hiển thị:

```txt
Today Safe-to-Spend: 185.000đ
```

## 20.2. Can I afford this?

Người dùng nhập một khoản định mua.

Ví dụ:

```txt
Tôi có nên mua đôi giày 1.500.000đ không?
```

App phân tích:

```txt
Tháng này bạn còn 2.100.000đ cho mục mua sắm.
Nhưng goal “Mua laptop” đang chậm 700.000đ.
Nếu mua đôi giày này, goal sẽ chậm thêm khoảng 9 ngày.
Gợi ý: vẫn có thể mua nếu bạn giảm ăn ngoài 300.000đ trong 2 tuần tới.
```

## 20.3. Goal Engine

Người dùng nhập goal lớn, app tự tách thành:

```txt
Saving goal
Budget adjustment
Tasks
Habits
Review schedule
Alerts
```

Ví dụ:

```txt
Tôi muốn có 30 triệu quỹ dự phòng trong 10 tháng.
```

App tạo:

```txt
Saving goal: 30.000.000đ
Monthly target: 3.000.000đ/tháng
Weekly task: review chi tiêu Chủ nhật
Habit: không vượt budget ăn ngoài
Alert: nếu tháng này tiết kiệm dưới 2.5 triệu
```

## 20.4. Anti-regret purchase

Tính năng chống mua đồ cảm xúc.

Flow:

```txt
Người dùng nhập món muốn mua
App tính ảnh hưởng đến budget/goal
Người dùng chọn thời gian chờ 1-7 ngày
Sau thời gian chờ, app hỏi lại có còn muốn mua không
Nếu không mua, app ghi nhận số tiền đã tránh được
```

Ví dụ:

```txt
Bạn vừa tránh được một khoản chi 3.000.000đ.
Số tiền này được chuyển gợi ý vào goal “Quỹ dự phòng”.
```

## 20.5. Spending Forecast

Dự báo cuối tháng.

Ví dụ:

```txt
Nếu giữ tốc độ chi tiêu hiện tại,
cuối tháng bạn sẽ vượt budget khoảng 1.200.000đ.
```

Hoặc:

```txt
Bạn đang đi đúng hướng.
Dự kiến cuối tháng còn dư 2.700.000đ.
```

## 20.6. Life Impact

Hiển thị tác động của khoản chi đến mục tiêu.

Ví dụ:

```txt
Bạn đã chi 840.000đ cho trà sữa tháng này.
Số tiền này tương đương 28% tiến độ goal “Khóa học tiếng Anh”.
```

## 20.7. Low Money Mode

Khi hệ thống phát hiện người dùng sắp cạn tiền hoặc vượt budget.

Ví dụ:

```txt
Low Money Mode bật đến cuối tháng.
Daily safe-to-spend: 90.000đ.
Ưu tiên: ăn uống, di chuyển, hóa đơn.
Tạm hoãn: mua sắm, giải trí, goal không quan trọng.
```

## 20.8. Weekly Life Review

Cuối tuần app tự tổng kết:

```txt
Tuần này bạn tiêu ít hơn tuần trước 12%.
Bạn hoàn thành 18/24 task.
Habit tốt nhất: học tiếng Anh 5/7 ngày.
Goal tài chính đang ổn.
Goal sức khỏe đang bị bỏ quên 9 ngày.
```

## 20.9. Personalized Challenges

Challenge dựa trên dữ liệu thật.

Ví dụ:

```txt
7 ngày không order đồ ăn sau 22h
Giảm Grab 30% trong tuần này
Không mua đồ công nghệ trong 14 ngày
Tự nấu 3 bữa/tuần
Hoàn thành 5 task liên quan đến goal học tập
```

## 20.10. What changed?

Phát hiện bất thường:

```txt
Tháng này tiền ăn ngoài tăng 42%.
Bạn có 2 subscription mới.
Chi tiêu lúc đêm muộn tăng gấp đôi.
Bạn bỏ lỡ review tài chính 3 tuần liên tiếp.
Goal học tập không có task nào trong 10 ngày.
```

---

# 21. UI/UX đề xuất

## 21.1. Các màn hình chính

```txt
Dashboard
Finance
Goals
Tasks
Habits
Calendar
Insights
Review
AI Assistant
Settings
```

## 21.2. Dashboard

Dashboard là màn hình quan trọng nhất.

Nên hiển thị:

```txt
Safe-to-spend hôm nay
Tổng thu/chi tháng này
Budget gần vượt
Goal quan trọng
Task hôm nay
Habit hôm nay
Insight nổi bật
Hóa đơn/khoản định kỳ sắp đến hạn
```

## 21.3. Insight Center

Danh sách các insight được app tạo tự động.

Mỗi insight gồm:

```txt
Title
Summary
Reason
Impact
Recommended actions
Status
CreatedAt
ExpiresAt
```

## 21.4. AI Assistant

Chat AI nên là tab phụ hoặc floating button.

Người dùng có thể hỏi:

```txt
Tháng này tôi tiêu nhiều nhất ở đâu?
Tôi có nên mua món này không?
Tạo kế hoạch tiết kiệm 5 triệu trong 2 tháng.
Tuần sau tôi nên ưu tiên goal nào?
Tại sao tôi hay bị trễ task?
```

---

# 22. Roadmap đề xuất

## Phase 1 — Finance MVP

Mục tiêu: có app tài chính cá nhân dùng được.

Chức năng:

```txt
Auth
Account/wallet
Category
Transaction CRUD
Budget theo tháng
Saving goal
Dashboard cơ bản
Report thu/chi
Manual input
CSV/Excel import cơ bản
```

Thời gian dự kiến nếu làm một mình:

```txt
6-10 tuần nếu đã quen .NET/frontend
3-4 tháng nếu vừa học vừa làm
```

## Phase 2 — Finance Intelligence

Chức năng:

```txt
Recurring transaction
Rule-based auto categorization
Safe-to-spend
Spending forecast
Budget alerts
Transaction duplicate detection
Import sao kê tốt hơn
```

## Phase 3 — Goals + Tasks + Habits

Chức năng:

```txt
Goal management
Goal milestones
Task management
Habit tracking
Liên kết goal với task/habit/finance
Weekly review cơ bản
```

## Phase 4 — Insight Center

Chức năng:

```txt
Insight engine
What changed?
Life impact
Low Money Mode
Personalized challenges
Weekly/monthly review tự động
```

## Phase 5 — AI Assistant

Chức năng:

```txt
AI insight explanation
AI question answering with context retrieval
Can I afford this?
Goal Engine
AI-generated action suggestions
User confirmation before applying AI actions
```

## Phase 6 — Automation & Integrations

Chức năng:

```txt
Bank webhook/API provider integration
Notification/email parser nếu cần
Google Calendar integration
Reminder/notification system
Mobile app nếu cần
```

---

# 23. Timeline tổng quan

```txt
3 tháng: MVP finance dùng được
6 tháng: finance + goal + habit/task cơ bản
12 tháng: sản phẩm đủ đẹp để show CV hoặc cho người khác dùng thử
18-24 tháng: sản phẩm khác biệt với AI, automation, insight, life dashboard
```

Ghi chú:

```txt
“Hoàn hảo” không có điểm kết thúc.
Nên làm theo vòng lặp nhỏ, dùng thật hằng ngày, rồi cải tiến.
```

---

# 24. Coding principles

## 24.1. Backend

```txt
Ưu tiên Clean Architecture rút gọn
Không over-engineering
Không tạo quá nhiều abstraction nếu chưa cần
Business logic không đặt trong Controller
Controller chỉ nhận request và trả response
Application xử lý use case
Domain chứa rule nghiệp vụ
Infrastructure xử lý database/external service
```

## 24.2. Naming

```txt
Entity dùng danh từ rõ nghĩa: Transaction, Budget, Goal
Command dùng động từ: CreateTransactionCommand
Query dùng dạng Get/List: GetMonthlySpendingQuery
Handler kết thúc bằng Handler
DTO kết thúc bằng Dto hoặc Response
```

## 24.3. Validation

Dùng FluentValidation hoặc validation rõ ràng trong Application layer.

Ví dụ:

```txt
Amount phải > 0
TransactionDate không được quá vô lý
Budget period không được overlap nếu cùng category
Saving goal target amount phải > 0
```

## 24.4. Result pattern

Nên dùng Result pattern thay vì throw exception cho lỗi nghiệp vụ thông thường.

Ví dụ:

```txt
Result.Success(data)
Result.Failure(error)
```

## 24.5. Time handling

Cần thống nhất timezone.

Gợi ý:

```txt
Lưu DateTimeOffset hoặc UTC trong database
Hiển thị theo timezone người dùng
Budget/report cần tính theo local date của user
```

---

# 25. Database design notes

## 25.1. User data isolation

Mọi dữ liệu cá nhân cần gắn với UserId.

Ví dụ:

```txt
Transaction.UserId
Account.UserId
Budget.UserId
Goal.UserId
TaskItem.UserId
Habit.UserId
```

## 25.2. Soft delete

Nên cân nhắc soft delete cho dữ liệu quan trọng.

```txt
IsDeleted
DeletedAt
```

## 25.3. Audit fields

Các entity chính nên có:

```txt
CreatedAt
UpdatedAt
CreatedBy
UpdatedBy
```

## 25.4. Money

Không dùng float/double cho tiền.

Dùng:

```txt
decimal
```

Cần có Currency nếu sau này hỗ trợ nhiều loại tiền.

---

# 26. Security & privacy notes

Dữ liệu rất nhạy cảm, cần quan tâm:

```txt
JWT authentication
Password hashing chuẩn
Không log dữ liệu nhạy cảm
Không log raw bank webhook chứa thông tin quá nhạy cảm nếu không cần
Encrypt dữ liệu nhạy cảm nếu cần
Cho phép export data
Cho phép xóa data
Role/permission nếu sau này multi-user
Rate limiting cho API public
Webhook signature validation nếu provider hỗ trợ
```

---

# 27. API endpoint gợi ý

## Auth

```txt
POST /api/auth/register
POST /api/auth/login
POST /api/auth/refresh-token
POST /api/auth/logout
```

## Finance

```txt
GET /api/accounts
POST /api/accounts
PUT /api/accounts/{id}
DELETE /api/accounts/{id}

GET /api/transactions
POST /api/transactions
GET /api/transactions/{id}
PUT /api/transactions/{id}
DELETE /api/transactions/{id}

GET /api/categories
POST /api/categories
PUT /api/categories/{id}
DELETE /api/categories/{id}

GET /api/budgets
POST /api/budgets
PUT /api/budgets/{id}
DELETE /api/budgets/{id}

GET /api/saving-goals
POST /api/saving-goals
PUT /api/saving-goals/{id}
DELETE /api/saving-goals/{id}
```

## Reports

```txt
GET /api/reports/monthly-summary
GET /api/reports/category-breakdown
GET /api/reports/cash-flow
GET /api/reports/safe-to-spend
GET /api/reports/spending-forecast
```

## Imports

```txt
POST /api/imports/bank-statement
GET /api/imports/{id}
POST /api/imports/{id}/confirm
POST /api/imports/{id}/cancel
```

## Integrations

```txt
POST /api/integrations/bank-webhooks/casso
POST /api/integrations/bank-webhooks/sepay
POST /api/integrations/bank-webhooks/generic
```

## Goals

```txt
GET /api/goals
POST /api/goals
GET /api/goals/{id}
PUT /api/goals/{id}
DELETE /api/goals/{id}
POST /api/goals/{id}/milestones
POST /api/goals/{id}/link-task
POST /api/goals/{id}/link-habit
POST /api/goals/{id}/link-saving-goal
```

## Tasks

```txt
GET /api/tasks
POST /api/tasks
GET /api/tasks/{id}
PUT /api/tasks/{id}
DELETE /api/tasks/{id}
POST /api/tasks/{id}/complete
```

## Habits

```txt
GET /api/habits
POST /api/habits
GET /api/habits/{id}
PUT /api/habits/{id}
DELETE /api/habits/{id}
POST /api/habits/{id}/check-in
```

## Insights

```txt
GET /api/insights
GET /api/insights/{id}
POST /api/insights/{id}/dismiss
POST /api/insights/{id}/action
```

## AI

```txt
POST /api/ai/ask
POST /api/ai/can-i-afford-this
POST /api/ai/generate-goal-plan
POST /api/ai/explain-insight/{insightId}
```

---

# 28. MVP scope nên làm trước

Để tránh quá tải, MVP đầu tiên chỉ nên làm:

```txt
Authentication
Account/wallet CRUD
Category CRUD
Transaction CRUD
Monthly budget
Saving goal
Dashboard cơ bản
Report theo category
Import CSV/Excel đơn giản
```

Chưa cần làm ngay:

```txt
AI full chat
Bank webhook phức tạp
Calendar integration
Mobile app
Microservices
Advanced analytics
```

---

# 29. Non-goals giai đoạn đầu

Không làm trong giai đoạn đầu:

```txt
Microservices
Multi-tenant enterprise system
Social network
Public community
Crypto/investment trading
Tự login ngân hàng
Scraping ngân hàng
AI tự động sửa dữ liệu không cần xác nhận
```

---

# 30. Dữ liệu mẫu nên seed

Nên seed một số category mặc định:

## Expense categories

```txt
Ăn uống
Di chuyển
Mua sắm
Giải trí
Học tập
Sức khỏe
Nhà cửa
Hóa đơn
Subscription
Bạn bè/gia đình
Khác
```

## Income categories

```txt
Lương
Freelance
Thưởng
Quà tặng
Đầu tư
Khác
```

## Account types

```txt
Cash
BankAccount
EWallet
CreditCard
Savings
Investment
```

## Goal types

```txt
Financial
Learning
Health
Career
Personal
Relationship
Other
```

---

# 31. Một số business rules quan trọng

```txt
Transaction amount luôn là số dương; Type quyết định thu/chi.
Transfer nên tạo movement giữa 2 account, không tính là income/expense trong report chi tiêu.
Budget có thể theo tháng và theo category.
Saving goal có target amount, current amount, deadline.
Safe-to-spend = số tiền còn có thể tiêu sau khi trừ chi phí cố định, budget cần giữ và saving goal target.
Recurring transaction có thể sinh transaction tự động nhưng nên cho trạng thái Pending nếu cần confirm.
Imported transaction cần check duplicate dựa trên amount, date, account, external id, description.
Webhook transaction nên lưu raw event để debug, nhưng cần chú ý bảo mật.
```

---

# 32. Công thức gợi ý

## 32.1. Monthly balance

```txt
MonthlyBalance = TotalIncome - TotalExpense
```

## 32.2. Saving rate

```txt
SavingRate = (TotalIncome - TotalExpense) / TotalIncome
```

## 32.3. Budget remaining

```txt
BudgetRemaining = BudgetLimit - ActualSpent
```

## 32.4. Daily safe-to-spend đơn giản

```txt
SafeToSpendPerDay = AvailableFlexibleMoney / RemainingDaysInPeriod
```

Trong đó:

```txt
AvailableFlexibleMoney = CurrentBalance
  - UpcomingFixedExpenses
  - RequiredSavingForGoals
  - ReservedBudget
```

## 32.5. Spending forecast đơn giản

```txt
ProjectedSpending = CurrentSpending / DaysPassed * TotalDaysInPeriod
```

---

# 33. AI prompt behavior notes

Khi AI trả lời người dùng trong app:

```txt
Không phán xét người dùng.
Không dùng giọng dọa nạt.
Không đưa lời khuyên tài chính rủi ro cao.
Luôn giải thích dựa trên dữ liệu nào.
Luôn đưa hành động nhỏ, thực tế.
Nếu thiếu dữ liệu, nói rõ thiếu dữ liệu.
Với hành động thay đổi dữ liệu, cần xin xác nhận.
```

Ví dụ tone tốt:

```txt
Tháng này bạn đang chi ăn ngoài cao hơn bình thường khoảng 540.000đ.
Điểm tăng chủ yếu nằm ở cuối tuần.
Nếu muốn quay lại mức tháng trước, bạn có thể thử giới hạn order cuối tuần còn 1 lần.
Mình có thể tạo một challenge 7 ngày để giúp bạn theo dõi.
```

---

# 34. Trải nghiệm người dùng mẫu

## 34.1. Buổi sáng

Dashboard hiển thị:

```txt
Hôm nay bạn còn có thể tiêu 170.000đ.
Goal “Quỹ dự phòng” đang đúng tiến độ.
Bạn có 2 task quan trọng.
Bạn đã order đồ ăn 3 lần tuần này.
Nếu order thêm hôm nay, bạn sẽ vượt habit limit.
3 ngày nữa đến hạn đóng tiền Internet.
```

## 34.2. Khi định mua đồ

Người dùng nhập:

```txt
Tôi muốn mua tai nghe 3.000.000đ.
```

App trả lời:

```txt
Bạn có thể mua, nhưng nó sẽ làm goal “Mua laptop” chậm khoảng 12 ngày.
Nếu vẫn muốn mua, bạn nên giảm budget giải trí 500.000đ trong tháng này
hoặc hoãn mua đến tháng sau để không ảnh hưởng goal.
```

## 34.3. Cuối tuần

App tự tạo review:

```txt
Tuần này bạn tiêu ít hơn tuần trước 12%.
Bạn hoàn thành 18/24 task.
Habit tốt nhất là học tiếng Anh 5/7 ngày.
Goal tài chính đang ổn.
Goal sức khỏe bị bỏ quên 9 ngày.
```

---

# 35. Tiêu chí thành công ban đầu

MVP thành công nếu:

```txt
Người dùng có thể nhập giao dịch nhanh.
Người dùng xem được tháng này đã tiêu bao nhiêu.
Người dùng biết hôm nay còn nên tiêu bao nhiêu.
Người dùng có thể tạo budget và saving goal.
Người dùng có ít nhất 1 insight hữu ích mỗi tuần.
Người dùng thấy app giúp họ ra quyết định tốt hơn, không chỉ ghi chép.
```

---

# 36. Định hướng dài hạn đáng giá nhất

5 tính năng nên ưu tiên nếu muốn sản phẩm thật sự khác biệt:

```txt
Safe-to-spend mỗi ngày
Can I afford this?
Goal Engine: biến goal thành budget + task + habit
Weekly Life Review tự động
AI Coach dựa trên dữ liệu thật của người dùng
```

Nếu chỉ làm app nhập giao dịch và xem biểu đồ, dự án sẽ khá bình thường.

Nếu làm được 5 tính năng trên, dự án sẽ khác biệt rõ ràng hơn.

---

# 37. Ghi chú cho AI code agent

Khi đọc tài liệu này và hỗ trợ code, hãy hiểu rằng:

```txt
Đây là dự án dài hạn, bắt đầu từ finance MVP.
Không code tất cả module cùng lúc.
Ưu tiên kiến trúc sạch nhưng không over-engineering.
Tập trung đầu tiên vào domain Finance.
Thiết kế database/API sao cho sau này mở rộng được sang Goals, Tasks, Habits, Insights và AI.
Không thiết kế AI như chatbot chính ngay từ đầu.
Dashboard, insight và action flow quan trọng hơn chat.
Mọi dữ liệu nhạy cảm cần được xử lý cẩn thận.
```

Thứ tự code đề xuất:

```txt
1. Setup solution Clean Architecture rút gọn
2. Auth cơ bản
3. Account entity + CRUD
4. Category entity + seed data
5. Transaction entity + CRUD
6. Monthly report
7. Budget
8. Saving goal
9. Dashboard summary
10. CSV/Excel import
11. Safe-to-spend
12. Rule-based insights
13. Goals/Tasks/Habits
14. AI context layer
15. AI assistant
```

---

# 38. Tinh thần sản phẩm

Dự án này không phải để tạo thêm một app khiến người dùng phải nhập nhiều dữ liệu hơn.

Dự án này nên giúp người dùng:

```txt
Hiểu bản thân hơn
Quản lý tiền tốt hơn
Biến mục tiêu thành hành động
Giảm quyết định cảm tính
Duy trì thói quen tốt
Nhìn lại cuộc sống theo tuần/tháng
Ra quyết định dựa trên dữ liệu cá nhân thật
```

Câu định hướng cuối cùng:

```txt
AI không phải giao diện chính.
AI là bộ não chạy phía sau, biến dữ liệu cá nhân thành insight và hành động.
```
