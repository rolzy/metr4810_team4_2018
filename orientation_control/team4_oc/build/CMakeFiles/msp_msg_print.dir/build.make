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
include CMakeFiles/msp_msg_print.dir/depend.make

# Include the progress variables for this target.
include CMakeFiles/msp_msg_print.dir/progress.make

# Include the compile flags for this target's objects.
include CMakeFiles/msp_msg_print.dir/flags.make

CMakeFiles/msp_msg_print.dir/src/msg_print.cpp.o: CMakeFiles/msp_msg_print.dir/flags.make
CMakeFiles/msp_msg_print.dir/src/msg_print.cpp.o: ../src/msg_print.cpp
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --progress-dir=/mnt/d/Stuff/Roland/Uni/2018Sem1Courses/metr4810_team4_2018/orientation_control/msp/build/CMakeFiles --progress-num=$(CMAKE_PROGRESS_1) "Building CXX object CMakeFiles/msp_msg_print.dir/src/msg_print.cpp.o"
	/usr/bin/c++   $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -o CMakeFiles/msp_msg_print.dir/src/msg_print.cpp.o -c /mnt/d/Stuff/Roland/Uni/2018Sem1Courses/metr4810_team4_2018/orientation_control/msp/src/msg_print.cpp

CMakeFiles/msp_msg_print.dir/src/msg_print.cpp.i: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Preprocessing CXX source to CMakeFiles/msp_msg_print.dir/src/msg_print.cpp.i"
	/usr/bin/c++  $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -E /mnt/d/Stuff/Roland/Uni/2018Sem1Courses/metr4810_team4_2018/orientation_control/msp/src/msg_print.cpp > CMakeFiles/msp_msg_print.dir/src/msg_print.cpp.i

CMakeFiles/msp_msg_print.dir/src/msg_print.cpp.s: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Compiling CXX source to assembly CMakeFiles/msp_msg_print.dir/src/msg_print.cpp.s"
	/usr/bin/c++  $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -S /mnt/d/Stuff/Roland/Uni/2018Sem1Courses/metr4810_team4_2018/orientation_control/msp/src/msg_print.cpp -o CMakeFiles/msp_msg_print.dir/src/msg_print.cpp.s

CMakeFiles/msp_msg_print.dir/src/msg_print.cpp.o.requires:

.PHONY : CMakeFiles/msp_msg_print.dir/src/msg_print.cpp.o.requires

CMakeFiles/msp_msg_print.dir/src/msg_print.cpp.o.provides: CMakeFiles/msp_msg_print.dir/src/msg_print.cpp.o.requires
	$(MAKE) -f CMakeFiles/msp_msg_print.dir/build.make CMakeFiles/msp_msg_print.dir/src/msg_print.cpp.o.provides.build
.PHONY : CMakeFiles/msp_msg_print.dir/src/msg_print.cpp.o.provides

CMakeFiles/msp_msg_print.dir/src/msg_print.cpp.o.provides.build: CMakeFiles/msp_msg_print.dir/src/msg_print.cpp.o


# Object files for target msp_msg_print
msp_msg_print_OBJECTS = \
"CMakeFiles/msp_msg_print.dir/src/msg_print.cpp.o"

# External object files for target msp_msg_print
msp_msg_print_EXTERNAL_OBJECTS =

libmsp_msg_print.so: CMakeFiles/msp_msg_print.dir/src/msg_print.cpp.o
libmsp_msg_print.so: CMakeFiles/msp_msg_print.dir/build.make
libmsp_msg_print.so: CMakeFiles/msp_msg_print.dir/link.txt
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --bold --progress-dir=/mnt/d/Stuff/Roland/Uni/2018Sem1Courses/metr4810_team4_2018/orientation_control/msp/build/CMakeFiles --progress-num=$(CMAKE_PROGRESS_2) "Linking CXX shared library libmsp_msg_print.so"
	$(CMAKE_COMMAND) -E cmake_link_script CMakeFiles/msp_msg_print.dir/link.txt --verbose=$(VERBOSE)

# Rule to build all files generated by this target.
CMakeFiles/msp_msg_print.dir/build: libmsp_msg_print.so

.PHONY : CMakeFiles/msp_msg_print.dir/build

CMakeFiles/msp_msg_print.dir/requires: CMakeFiles/msp_msg_print.dir/src/msg_print.cpp.o.requires

.PHONY : CMakeFiles/msp_msg_print.dir/requires

CMakeFiles/msp_msg_print.dir/clean:
	$(CMAKE_COMMAND) -P CMakeFiles/msp_msg_print.dir/cmake_clean.cmake
.PHONY : CMakeFiles/msp_msg_print.dir/clean

CMakeFiles/msp_msg_print.dir/depend:
	cd /mnt/d/Stuff/Roland/Uni/2018Sem1Courses/metr4810_team4_2018/orientation_control/msp/build && $(CMAKE_COMMAND) -E cmake_depends "Unix Makefiles" /mnt/d/Stuff/Roland/Uni/2018Sem1Courses/metr4810_team4_2018/orientation_control/msp /mnt/d/Stuff/Roland/Uni/2018Sem1Courses/metr4810_team4_2018/orientation_control/msp /mnt/d/Stuff/Roland/Uni/2018Sem1Courses/metr4810_team4_2018/orientation_control/msp/build /mnt/d/Stuff/Roland/Uni/2018Sem1Courses/metr4810_team4_2018/orientation_control/msp/build /mnt/d/Stuff/Roland/Uni/2018Sem1Courses/metr4810_team4_2018/orientation_control/msp/build/CMakeFiles/msp_msg_print.dir/DependInfo.cmake --color=$(COLOR)
.PHONY : CMakeFiles/msp_msg_print.dir/depend

