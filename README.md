# How the NumberToWordsConverter Class Works

## Overview

The class uses 'String Interpolation' which means it inserts values into a string template. This allows us to create strings by embedding expressions directly within string literals.

- **Division (`/`)**: This operation is used to determine the tens place.
- **Modulo (`%`)**: This operation is used to determine the units place.
- **`TrimEnd('-')`**: Removes any trailing hyphen if the units place is zero.

## Let's Go Through a Toy Example

We'll use the number **42**, the answer to everything in the universe, as our first example to explain these operations.

### 1. Understanding the Number

- **42** is composed of:
  - **4 tens**
  - **2 units**

### 2. Breaking It Down

- **Tens Place Calculation**:

  - `number / 10` gives you the tens place.
  - **42 / 10 = 4** (because integer division discards the decimal).

- **Units Place Calculation**:
  - `number % 10` gives you the remainder, which is the units place.
  - **42 % 10 = 2**.

### 3. Mapping Numbers to Words

Using the `TensMap` and `UnitsMap` arrays:

- **TensMap[4] = "Forty"**
- **UnitsMap[2] = "Two"**

### 4. Building the String

Using string interpolation to build the final result:

```csharp
$"{TensMap[number / 10]}-{UnitsMap[number % 10]}"
```

- `TensMap[number / 10]`: Maps 4 to "Forty".
- `UnitsMap[number % 10]`: Maps 2 to "Two".
- Result: `"Forty-Two"`

### 5. Removing Trailing Hyphen

In cases where the number is a multiple of ten, like **40**, you don't need the hyphen:

- For **40**:
  - **40 / 10 = 4** → "Forty"
  - **40 % 10 = 0** → "Zero" (no units needed)
- After string construction: `"Forty-Zero"`.
- `TrimEnd('-')`: Removes the trailing hyphen to produce `"Forty"`.

## Handling Incorrect Inputs

- **Decimal.TryParse**: The `decimal.TryParse` method is preferred over direct conversion methods like Convert.ToDecimal because it gracefully handles invalid inputs without throwing exceptions.

- **TryGetValue Method**: This method attempts to retrieve the value associated with the "amount" form field. It checks if the field exists and has a value.

- **Handling Missing Fields**: If the form field does not exist or has no value, the code assigns "No input provided." to SubmittedAmount and leaves ConvertedAmount empty. This handles cases where the user submits the form without entering anything.

Sure thing, my dude! Let's dive into how the `ConvertWholeNumberToWords` function works with recursion to convert a whole number into its word representation. We'll walk through an example step-by-step to understand how recursive calls help break down and build up the solution.

## Recursive ConvertWholeNumberToWords Function

### Recursive Breakdown

Let's take a number, say **1234567**, and see how the recursive calls work.

#### Example: 1234567

Here's a detailed walkthrough:

1. **Initial Call:** `ConvertWholeNumberToWords(1234567)`

   - **Condition Check:**
     - **1234567 < 1000000:** False
     - **1234567 < 1000000000:** True
   - **Action:** Divide by 1,000,000 to find millions and call recursively for the remainder:
     - **Millions:** `1234567 / 1000000 = 1`
     - **Remainder:** `1234567 % 1000000 = 234567`
   - **Result:** `"One million " + ConvertWholeNumberToWords(234567)`

2. **Second Call:** `ConvertWholeNumberToWords(234567)`

   - **Condition Check:**
     - **234567 < 1000:** False
     - **234567 < 1000000:** True
   - **Action:** Divide by 1,000 to find thousands and call recursively for the remainder:
     - **Thousands:** `234567 / 1000 = 234`
     - **Remainder:** `234567 % 1000 = 567`
   - **Result:** `"Two hundred thirty-four thousand " + ConvertWholeNumberToWords(567)`

3. **Third Call:** `ConvertWholeNumberToWords(567)`

   - **Condition Check:**
     - **567 < 100:** False
     - **567 < 1000:** True
   - **Action:** Divide by 100 to find hundreds and call recursively for the remainder:
     - **Hundreds:** `567 / 100 = 5`
     - **Remainder:** `567 % 100 = 67`
   - **Result:** `"Five hundred " + ConvertWholeNumberToWords(67)`

4. **Fourth Call:** `ConvertWholeNumberToWords(67)`

   - **Condition Check:**
     - **67 < 20:** False
     - **67 < 100:** True
   - **Action:** Divide by 10 to find tens and call recursively for the remainder:
     - **Tens:** `67 / 10 = 6`
     - **Remainder:** `67 % 10 = 7`
   - **Result:** `"Sixty-" + ConvertWholeNumberToWords(7)`

5. **Fifth Call:** `ConvertWholeNumberToWords(7)`

   - **Condition Check:**
     - **7 < 20:** True
   - **Action:** Use the `UnitsMap` to find the word for 7.
   - **Result:** `"Seven"`

### Building the Final Result

Now, let's piece together the results from each recursive call:

1. **Fifth Call:** `ConvertWholeNumberToWords(7)` returns `"Seven"`.
2. **Fourth Call:** `"Sixty-" + "Seven"` becomes `"Sixty-Seven"`.
3. **Third Call:** `"Five hundred " + "Sixty-Seven"` becomes `"Five hundred Sixty-Seven"`.
4. **Second Call:** `"Two hundred thirty-four thousand " + "Five hundred Sixty-Seven"` becomes `"Two hundred thirty-four thousand Five hundred Sixty-Seven"`.
5. **Initial Call:** `"One million " + "Two hundred thirty-four thousand Five hundred Sixty-Seven"` becomes `"One million Two hundred thirty-four thousand Five hundred Sixty-Seven"`.

### Result

The final result for the input `1234567` is:

```
"One million Two hundred thirty-four thousand Five hundred Sixty-Seven"
```

### Key Concepts

- **Recursion:** Each call breaks down the number into smaller parts, processing one segment at a time.
- **Base Case:** When `number < 20`, the recursion stops, and a direct lookup is done.
- **String Construction:** The results of recursive calls are combined to build the complete number in words.

---

# How To Install

## Step-by-Step Guide

### 1. **Clone the Repository**

1. **Open Terminal or Command Prompt:**

   Start by opening your terminal (Mac/Linux) or Command Prompt/PowerShell (Windows).

2. **Navigate to Your Desired Directory:**

   Choose where you want to clone the repository. Use the `cd` command to navigate to that directory:

   ```bash
   cd /path/to/your/directory
   ```

3. **Clone the Repository:**

   Use `git clone` to clone the repository. Replace `your-repo-url` with the actual URL of your GitHub repository:

   ```bash
   git clone https://github.com/williammcintosh/ChequeWriterApp.git
   ```

   This will create a local copy of the repository in a new directory named `ChequeWriterApp`.

### 2. **Navigate to the Project Directory**

Once the repository is cloned, navigate into the project directory:

```bash
cd ChequeWriterApp
```

### 3. **Restore NuGet Packages**

1. **Restore Packages:**

   Run the following command to restore any NuGet packages needed by the project:

   ```bash
   dotnet restore
   ```

   This command will download any dependencies specified in the `.csproj` file to ensure the project is ready to build.

### 4. **Build the Project**

1. **Build the Project:**

   Use the `dotnet build` command to compile the project and check for any errors:

   ```bash
   dotnet build
   ```

   This will compile the application and prepare it for running. If there are any errors, the terminal will display them, and you can address them before proceeding.

### 5. **Run the Application**

1. **Start the Development Server:**

   Use the `dotnet run` command to run the application:

   ```bash
   dotnet run
   ```

   This command will start the Kestrel web server and host your application locally.

2. **Access the Application:**

   - Open a web browser and go to the following URL: `http://localhost:5000` (or a different port if specified in the terminal output).
     - Mine was port `http://localhost:5218`.
   - You should see your application's home page, which includes the cheque writer form.

### 6. **Test the Application**

1. **Test Functionality:**

   - Enter a number in the input field and submit the form to see if it correctly converts numbers to words.

2. **Verify Results:**

   - Check if the number is converted and displayed in words as expected, ensuring everything works as intended.

# Challenges

The [Dot Net Microsoft tutorial](https://dotnet.microsoft.com/en-us/learn/dotnet/hello-world-tutorial/intro) that I used explicitly uses C#. Once I got that to work with recursion and use of division and modulo, I was not able to convert the project over to a VB.NET project. I even tried creating a simple "Hello World!" web project and couldn't get it working without an explosions of errors.
