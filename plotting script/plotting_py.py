import matplotlib.pyplot as plt
import pandas as pd

# Define the columns to use
columns = ["time", "x", "y", "z"]

# Read the CSV file
df = pd.read_csv(
    "logRight Controller-2024-12-19T15-19-59Z.csv",
    delimiter=';', 
    decimal='.',  # Adjust to ',' if needed for decimals
    usecols=columns
)

# Apply scaling to x and y coordinates
x = df["x"] 
y = df["y"] 

plt.plot(x, y, marker='o')

plt.xlabel('X-axis')  
plt.ylabel('Y-axis')

plt.title('X Y Coordinates Over Time')  
plt.show()