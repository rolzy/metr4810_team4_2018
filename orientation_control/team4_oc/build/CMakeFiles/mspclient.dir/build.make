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
include CMakeFiles/mspclient.dir/depend.make

# Include the progress variables for this target.
include CMakeFiles/mspclient.dir/progress.make

# Include the compile flags for this target's objects.
include CMakeFiles/mspclient.dir/flags.make

CMakeFiles/mspclient.dir/src/Client.cpp.o: CMakeFiles/mspclient.dir/flags.make
CMakeFiles/mspclient.dir/src/Client.cpp.o: ../src/Client.cpp
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --progress-dir=/mnt/d/Stuff/Roland/Uni/2018Sem1Courses/metr4810_team4_2018/orientation_control/msp/build/CMakeFiles --progress-num=$(CMAKE_PROGRESS_1) "Building CXX object CMakeFiles/mspclient.dir/src/Client.cpp.o"
	/usr/bin/c++   $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -o CMakeFiles/mspclient.dir/src/Client.cpp.o -c /mnt/d/Stuff/Roland/Uni/2018Sem1Courses/metr4810_team4_2018/orientation_control/msp/src/Client.cpp

CMakeFiles/mspclient.dir/src/Client.cpp.i: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Preprocessing CXX source to CMakeFiles/mspclient.dir/src/Client.cpp.i"
	/usr/bin/c++  $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -E /mnt/d/Stuff/Roland/Uni/2018Sem1Courses/metr4810_team4_2018/orientation_control/msp/src/Client.cpp > CMakeFiles/mspclient.dir/src/Client.cpp.i

CMakeFiles/mspclient.dir/src/Client.cpp.s: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Compiling CXX source to assembly CMakeFiles/mspclient.dir/src/Client.cpp.s"
	/usr/bin/c++  $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -S /mnt/d/Stuff/Roland/Uni/2018Sem1Courses/metr4810_team4_2018/orientation_control/msp/src/Client.cpp -o CMakeFiles/mspclient.dir/src/Client.cpp.s

CMakeFiles/mspclient.dir/src/Client.cpp.o.requires:

.PHONY : CMakeFiles/mspclient.dir/src/Client.cpp.o.requires

CMakeFiles/mspclient.dir/src/Client.cpp.o.provides: CMakeFiles/mspclient.dir/src/Client.cpp.o.requires
	$(MAKE) -f CMakeFiles/mspclient.dir/build.make CMakeFiles/mspclient.dir/src/Client.cpp.o.provides.build
.PHONY : CMakeFiles/mspclient.dir/src/Client.cpp.o.provides

CMakeFiles/mspclient.dir/src/Client.cpp.o.provides.build: CMakeFiles/mspclient.dir/src/Client.cpp.o


# Object files for target mspclient
mspclient_OBJECTS = \
"CMakeFiles/mspclient.dir/src/Client.cpp.o"

# External object files for target mspclient
mspclient_EXTERNAL_OBJECTS =

libmspclient.so: CMakeFiles/mspclient.dir/src/Client.cpp.o
libmspclient.so: CMakeFiles/mspclient.dir/build.make
libmspclient.so: CMakeFiles/mspclient.dir/link.txt
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --bold --progress-dir=/mnt/d/Stuff/Roland/Uni/2018Sem1Courses/metr4810_team4_2018/orientation_control/msp/build/CMakeFiles --progress-num=$(CMAKE_PROGRESS_2) "Linking CXX shared library libmspclient.so"
	$(CMAKE_COMMAND) -E cmake_link_script CMakeFiles/mspclient.dir/link.txt --verbose=$(VERBOSE)

# Rule to build all files generated by this target.
CMakeFiles/mspclient.dir/build: libmspclient.so

.PHONY : CMakeFiles/mspclient.dir/build

CMakeFiles/mspclient.dir/requires: CMakeFiles/mspclient.dir/src/Client.cpp.o.requires

.PHONY : CMakeFiles/mspclient.dir/requires

CMakeFiles/mspclient.dir/clean:
	$(CMAKE_COMMAND) -P CMakeFiles/mspclient.dir/cmake_clean.cmake
.PHONY : CMakeFiles/mspclient.dir/clean

CMakeFiles/mspclient.dir/depend:
	cd /mnt/d/Stuff/Roland/Uni/2018Sem1Courses/metr4810_team4_2018/orientation_control/msp/build && $(CMAKE_COMMAND) -E cmake_depends "Unix Makefiles" /mnt/d/Stuff/Roland/Uni/2018Sem1Courses/metr4810_team4_2018/orientation_control/msp /mnt/d/Stuff/Roland/Uni/2018Sem1Courses/metr4810_team4_2018/orientation_control/msp /mnt/d/Stuff/Roland/Uni/2018Sem1Courses/metr4810_team4_2018/orientation_control/msp/build /mnt/d/Stuff/Roland/Uni/2018Sem1Courses/metr4810_team4_2018/orientation_control/msp/build /mnt/d/Stuff/Roland/Uni/2018Sem1Courses/metr4810_team4_2018/orientation_control/msp/build/CMakeFiles/mspclient.dir/DependInfo.cmake --color=$(COLOR)
.PHONY : CMakeFiles/mspclient.dir/depend

