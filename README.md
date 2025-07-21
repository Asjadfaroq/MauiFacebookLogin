# MauiFacebookLogin
This project demonstrates how to implement Facebook Login in a cross-platform .NET MAUI application for both Android and iOS using WebAuthenticator. It provides a clean and modular approach to authenticating users with Facebook, retrieving access tokens, and handling secure redirects.

===================================================================

# Facebook Login Setup for .NET MAUI

Complete guide to integrate Facebook Login into your .NET MAUI app for Android and iOS platforms.

## Prerequisites

- Facebook Developer Account
- .NET MAUI development environment
- Hosting solution for data deletion callback (Vercel recommended)
- Android SDK and/or Xcode

## Step 1: Create Facebook App

1. Go to [Facebook Developers](https://developers.facebook.com) and create an account
2. Click "Create App" → Select "Consumer"
3. Fill in app details and save your App ID and App Secret
4. Navigate to Settings → Basic and complete:
   - Privacy Policy URL: `https://your-domain.com/privacy`
   - Terms of Service URL: `https://your-domain.com/terms`
   - User Data Deletion: `https://your-domain.com/api/data-deletion`
   - Upload 1024x1024px app icon

## Step 2: Configure Facebook Login

1. Add Facebook Login product to your app
2. Go to Facebook Login → Settings:
   - Enable Client OAuth Login
   - Enable Embedded Browser OAuth Login

## Step 3: Add Mobile Platforms

### Android Platform

1. Click "Add Platform" → Android
2. Configure:
   - Package Name: `com.yourcompany.yourapp`
   - Class Name: `MainActivity`
   - Key Hashes: Generate using commands below

```bash
# Development Key Hash
keytool -exportcert -alias androiddebugkey -keystore ~/.android/debug.keystore -storepass android -keypass android | openssl sha1 -binary | openssl base64

# Production Key Hash  
keytool -exportcert -alias YOUR_RELEASE_ALIAS -keystore path/to/release.keystore | openssl sha1 -binary | openssl base64
```

### iOS Platform

1. Click "Add Platform" → iOS
2. Configure:
   - Bundle ID: `com.yourcompany.yourapp` (must match Info.plist exactly)

## Step 4: Set Up Data Deletion Callback

Create a hosted endpoint that accepts POST requests and returns:

```json
{
  "url": "https://yourdomain.com/deletion-status/12345",
  "confirmation_code": "unique_code_12345"
}
```

Free hosting options: Vercel, Netlify Functions, Railway

## Step 5: Configure Your MAUI Project

Your project already includes all necessary code and packages. Simply replace these values:

| Replace This | With Your Value | Found In |
|--------------|-----------------|----------|
| `YOUR_FACEBOOK_APP_ID` | Your App ID | Facebook Console → Settings → Basic |
| `YOUR_FACEBOOK_CLIENT_TOKEN` | Client Token | Settings → Advanced → Security |
| `com.yourcompany.yourapp` | Your package/bundle ID | Must match platform settings |

**Important:** Never commit sensitive values to version control.

## Step 6: Test Your Setup

```bash
# Build and test
dotnet build -f net8.0-android
dotnet run -f net8.0-android

dotnet build -f net8.0-ios     # macOS only
dotnet run -f net8.0-ios
```

As the app owner, you can login immediately. Other users need app approval.

## Step 7: Submit for App Review (Go Public)

1. Go to App Review in Facebook Console
2. Request permissions: `public_profile`, `email`
3. Provide:
   - App description and screenshots
   - Why you need user data
   - Privacy policy and terms links
4. Submit and wait 2-7 days for approval

## Common Issues & Quick Fixes

### "Invalid Key Hash" (Android)
- Regenerate hash with exact commands above
- Add both debug and release hashes

### "Invalid Bundle ID" (iOS)
- Ensure Bundle ID in Info.plist matches Facebook settings exactly

### "App Not Set Up"
- Verify Facebook Login product is added
- Check package name/bundle ID matches exactly

### Works in Debug, Not Release
- Add release key hash for Android
- Test release builds on physical devices

## Platform Requirements

- **Android:** API 24+ (Android 7.0)
- **iOS:** iOS 11.0+

## Security Best Practices

- Use secure storage for tokens
- Never commit App Secret to version control
- Implement proper error handling
- Use HTTPS in production
- Validate all user inputs

## Key Resources

- [Facebook Login Docs](https://developers.facebook.com/docs/facebook-login/)
- [.NET MAUI Documentation](https://docs.microsoft.com/en-us/dotnet/maui/)
- [App Review Guidelines](https://developers.facebook.com/docs/app-review/)

---

**Note:** During development, only app owners can login. After Facebook approval, anyone can use your app's login feature.
