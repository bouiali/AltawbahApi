# ===============================
# 🚧 المرحلة الأولى: البناء
# ===============================
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# نسخ ملف المشروع واستعادة الحزم
COPY *.csproj ./
RUN dotnet restore

# نسخ بقية الملفات وبناء المشروع
COPY . ./
RUN dotnet publish -c Release -o /app/publish

# ===============================
# 🚀 المرحلة الثانية: التشغيل
# ===============================
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app

# إعداد البورت الذي يعمل عليه التطبيق داخل الحاوية
ENV ASPNETCORE_URLS=http://+:10000

# نسخ الملفات المنشورة
COPY --from=build /app/publish .

# كشف البورت لمنصة Render
EXPOSE 10000

# أمر التشغيل
ENTRYPOINT ["dotnet", "TawbahApi.dll"]
