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
CMAKE_SOURCE_DIR = /mnt/d/Stuff/Roland/Uni/2018Sem1Courses/metr4810_team4_2018/orientation_control/team4_oc

# The top-level build directory on which CMake was run.
CMAKE_BINARY_DIR = /mnt/d/Stuff/Roland/Uni/2018Sem1Courses/metr4810_team4_2018/orientation_control/team4_oc/build

# Include any dependencies generated for this target.
include CMakeFiles/sensing.dir/depend.make

# Include the progress variables for this target.
include CMakeFiles/sensing.dir/progress.make

# Include the compile flags for this target's objects.
include CMakeFiles/sensing.dir/flags.make

CMakeFiles/sensing.dir/examples/sensing.cpp.o: CMakeFiles/sensing.dir/flags.make
CMakeFiles/sensing.dir/examples/sensing.cpp.o: ../examples/sensing.cpp
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --progress-dir=/mnt/d/Stuff/Roland/Uni/2018Sem1Courses/metr4810_team4_2018/orientation_control/team4_oc/build/CMakeFiles --progress-num=$(CMAKE_PROGRESS_1) "Building CXX object CMakeFiles/sensing.dir/examples/sensing.cpp.o"
	/usr/bin/c++   $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -o CMakeFiles/sensing.dir/examples/sensing.cpp.o -c /mnt/d/Stuff/Roland/Uni/2018Sem1Courses/metr4810_team4_2018/orientation_control/team4_oc/examples/sensing.cpp

CMakeFiles/sensing.dir/examples/sensing.cpp.i: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Preprocessing CXX source to CMakeFiles/sensing.dir/examples/sensing.cpp.i"
	/usr/bin/c++  $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -E /mnt/d/Stuff/Roland/Uni/2018Sem1Courses/metr4810_team4_2018/orientation_control/team4_oc/examples/sensing.cpp > CMakeFiles/sensing.dir/examples/sensing.cpp.i

CMakeFiles/sensing.dir/examples/sensing.cpp.s: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Compiling CXX source to assembly CMakeFiles/sensing.dir/examples/sensing.cpp.s"
	/usr/bin/c++  $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -S /mnt/d/Stuff/Roland/Uni/2018Sem1Courses/metr4810_team4_2018/orientation_control/team4_oc/examples/sensing.cpp -o CMakeFiles/sensing.dir/examples/sensing.cpp.s

CMakeFiles/sensing.dir/examples/sensing.cpp.o.requires:

.PHONY : CMakeFiles/sensing.dir/examples/sensing.cpp.o.requires

CMakeFiles/sensing.dir/examples/sensing.cpp.o.provides: CMakeFiles/sensing.dir/examples/sensing.cpp.o.requires
	$(MAKE) -f CMakeFiles/sensing.dir/build.make CMakeFiles/sensing.dir/examples/sensing.cpp.o.provides.build
.PHONY : CMakeFiles/sensing.dir/examples/sensing.cpp.o.provides

CMakeFiles/sensing.dir/examples/sensing.cpp.o.provides.build: CMakeFiles/sensing.dir/examples/sensing.cpp.o


# Object files for target sensing
sensing_OBJECTS = \
"CMakeFiles/sensing.dir/examples/sensing.cpp.o"

# External object files for target sensing
sensing_EXTERNAL_OBJECTS =

sensing: CMakeFiles/sensing.dir/examples/sensing.cpp.o
sensing: CMakeFiles/sensing.dir/build.make
sensing: libmsp.so
sensing: libmsp_msg_print.so
sensing: libmsp_fcu.so
sensing: libmspclient.so
sensing: CMakeFiles/sensing.dir/link.txt
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --bold --progress-dir=/mnt/d/Stuff/Roland/Uni/2018Sem1Courses/metr4810_team4_2018/orientation_control/team4_oc/build/CMakeFiles --progress-num=$(CMAKE_PROGRESS_2) "Linking CXX executable sensing"
	$(CMAKE_COMMAND) -E cmake_link_script CMakeFiles/sensing.dir/link.txt --verbose=$(VERBOSE)

# Rule to build all files generated by this target.
CMakeFiles/sensing.dir/build: sensing

.PHONY : CMakeFiles/sensing.dir/build

CMakeFiles/sensing.dir/requires: CMakeFiles/sensing.dir/examples/sensing.cpp.o.requires

.PHONY : CMakeFiles/sensing.dir/requires

CMakeFiles/sensing.dir/clean:
	$(CMAKE_COMMAND) -P CMakeFiles/sensing.dir/cmake_clean.cmake
.PHONY : CMakeFiles/sensing.dir/clean

CMakeFiles/sensing.dir/depend:
	cd /mnt/d/Stuff/Roland/Uni/2018Sem1Courses/metr4810_team4_2018/orientation_control/team4_oc/build && $(CMAKE_COMMAND) -E cmake_depends "Unix Makefiles" /mnt/d/Stuff/Roland/Uni/2018Sem1Courses/metr4810_team4_2018/orientation_control/team4_oc /mnt/d/Stuff/Roland/Uni/2018Sem1Courses/metr4810_team4_2018/orientation_control/team4_oc /mnt/d/Stuff/Roland/Uni/2018Sem1Courses/metr4810_team4_2018/orientation_control/team4_oc/build /mnt/d/Stuff/Roland/Uni/2018Sem1Courses/metr4810_team4_2018/orientation_control/team4_oc/build /mnt/d/Stuff/Roland/Uni/2018Sem1Courses/metr4810_team4_2018/orientation_control/team4_oc/build/CMakeFiles/sensing.dir/DependInfo.cmake --color=$(COLOR)
.PHONY : CMakeFiles/sensing.dir/depend

