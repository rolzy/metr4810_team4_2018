# CMAKE generated file: DO NOT EDIT!
# Generated by "Unix Makefiles" Generator, CMake Version 3.5

# Delete rule output on recipe failure.
.DELETE_ON_ERROR:


#=============================================================================
# Special targets provided by cmake.

# Disable implicit rules so canonical targets will work.
.SUFFIXES:


# Remove some rules from gmake that .SUFFIXES does not remove.
SUFFIXES =

.SUFFIXES: .hpux_make_needs_suffix_list


# Suppress display of executed commands.
$(VERBOSE).SILENT:


# A target that is always out of date.
cmake_force:

.PHONY : cmake_force

#=============================================================================
# Set environment variables for the build.

# The shell in which to execute make rules.
SHELL = /bin/sh

# The CMake executable.
CMAKE_COMMAND = /usr/bin/cmake

# The command to remove a file.
RM = /usr/bin/cmake -E remove -f

# Escaping for special characters.
EQUALS = =

# The top-level source directory on which CMake was run.
CMAKE_SOURCE_DIR = /mnt/d/Stuff/Roland/Uni/2018Sem1Courses/metr4810_team4_2018/orientation_control/msp

# The top-level build directory on which CMake was run.
CMAKE_BINARY_DIR = /mnt/d/Stuff/Roland/Uni/2018Sem1Courses/metr4810_team4_2018/orientation_control/msp/build

# Include any dependencies generated for this target.
include CMakeFiles/motor.dir/depend.make

# Include the progress variables for this target.
include CMakeFiles/motor.dir/progress.make

# Include the compile flags for this target's objects.
include CMakeFiles/motor.dir/flags.make

CMakeFiles/motor.dir/examples/motor.cpp.o: CMakeFiles/motor.dir/flags.make
CMakeFiles/motor.dir/examples/motor.cpp.o: ../examples/motor.cpp
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --progress-dir=/mnt/d/Stuff/Roland/Uni/2018Sem1Courses/metr4810_team4_2018/orientation_control/msp/build/CMakeFiles --progress-num=$(CMAKE_PROGRESS_1) "Building CXX object CMakeFiles/motor.dir/examples/motor.cpp.o"
	/usr/bin/c++   $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -o CMakeFiles/motor.dir/examples/motor.cpp.o -c /mnt/d/Stuff/Roland/Uni/2018Sem1Courses/metr4810_team4_2018/orientation_control/msp/examples/motor.cpp

CMakeFiles/motor.dir/examples/motor.cpp.i: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Preprocessing CXX source to CMakeFiles/motor.dir/examples/motor.cpp.i"
	/usr/bin/c++  $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -E /mnt/d/Stuff/Roland/Uni/2018Sem1Courses/metr4810_team4_2018/orientation_control/msp/examples/motor.cpp > CMakeFiles/motor.dir/examples/motor.cpp.i

CMakeFiles/motor.dir/examples/motor.cpp.s: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Compiling CXX source to assembly CMakeFiles/motor.dir/examples/motor.cpp.s"
	/usr/bin/c++  $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -S /mnt/d/Stuff/Roland/Uni/2018Sem1Courses/metr4810_team4_2018/orientation_control/msp/examples/motor.cpp -o CMakeFiles/motor.dir/examples/motor.cpp.s

CMakeFiles/motor.dir/examples/motor.cpp.o.requires:

.PHONY : CMakeFiles/motor.dir/examples/motor.cpp.o.requires

CMakeFiles/motor.dir/examples/motor.cpp.o.provides: CMakeFiles/motor.dir/examples/motor.cpp.o.requires
	$(MAKE) -f CMakeFiles/motor.dir/build.make CMakeFiles/motor.dir/examples/motor.cpp.o.provides.build
.PHONY : CMakeFiles/motor.dir/examples/motor.cpp.o.provides

CMakeFiles/motor.dir/examples/motor.cpp.o.provides.build: CMakeFiles/motor.dir/examples/motor.cpp.o


# Object files for target motor
motor_OBJECTS = \
"CMakeFiles/motor.dir/examples/motor.cpp.o"

# External object files for target motor
motor_EXTERNAL_OBJECTS =

motor: CMakeFiles/motor.dir/examples/motor.cpp.o
motor: CMakeFiles/motor.dir/build.make
motor: libmsp_fcu.so
motor: libmspclient.so
motor: CMakeFiles/motor.dir/link.txt
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --bold --progress-dir=/mnt/d/Stuff/Roland/Uni/2018Sem1Courses/metr4810_team4_2018/orientation_control/msp/build/CMakeFiles --progress-num=$(CMAKE_PROGRESS_2) "Linking CXX executable motor"
	$(CMAKE_COMMAND) -E cmake_link_script CMakeFiles/motor.dir/link.txt --verbose=$(VERBOSE)

# Rule to build all files generated by this target.
CMakeFiles/motor.dir/build: motor

.PHONY : CMakeFiles/motor.dir/build

CMakeFiles/motor.dir/requires: CMakeFiles/motor.dir/examples/motor.cpp.o.requires

.PHONY : CMakeFiles/motor.dir/requires

CMakeFiles/motor.dir/clean:
	$(CMAKE_COMMAND) -P CMakeFiles/motor.dir/cmake_clean.cmake
.PHONY : CMakeFiles/motor.dir/clean

CMakeFiles/motor.dir/depend:
	cd /mnt/d/Stuff/Roland/Uni/2018Sem1Courses/metr4810_team4_2018/orientation_control/msp/build && $(CMAKE_COMMAND) -E cmake_depends "Unix Makefiles" /mnt/d/Stuff/Roland/Uni/2018Sem1Courses/metr4810_team4_2018/orientation_control/msp /mnt/d/Stuff/Roland/Uni/2018Sem1Courses/metr4810_team4_2018/orientation_control/msp /mnt/d/Stuff/Roland/Uni/2018Sem1Courses/metr4810_team4_2018/orientation_control/msp/build /mnt/d/Stuff/Roland/Uni/2018Sem1Courses/metr4810_team4_2018/orientation_control/msp/build /mnt/d/Stuff/Roland/Uni/2018Sem1Courses/metr4810_team4_2018/orientation_control/msp/build/CMakeFiles/motor.dir/DependInfo.cmake --color=$(COLOR)
.PHONY : CMakeFiles/motor.dir/depend

